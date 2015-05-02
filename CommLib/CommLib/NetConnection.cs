using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace CommLib
{
  public abstract class NetConnection : IDisposable
  {
    private ConnectionDirection _direction = ConnectionDirection.Inbound;
    private Thread _worker = null;
    private bool _shouldAbort = true;

    public event Delegates.ExceptionDelegate ExceptionOccured;
    private void OnExceptionOccured(Exception ex)
    {
      if (ExceptionOccured != null) ExceptionOccured(ex);
    }

    public event Delegates.NetDataDelegate DataReceived;
    internal void OnDataReceived(NetConnection client, byte[] data)
    {
      if (DataReceived != null) DataReceived(client, data);
    }

    public ConnectionDirection Direction
    {
      get { return _direction; }
    }

    public NetConnection(ConnectionDirection direction)
    {
      _direction = direction;
      ThreadStart start = new ThreadStart(ThreadWorker);
      _worker = new Thread(start);
      _shouldAbort = false;
      _worker.Start();
    }

    private void ThreadWorker()
    {
      while (!_shouldAbort)
      {
        try
        {
          HandleConnection();
          Thread.Sleep(1);
        }
        catch (ThreadInterruptedException)
        {
          break;
        }
        catch (Exception ex)
        {
          OnExceptionOccured(ex);
        }
      }
    }

    public abstract void HandleConnection();
    public abstract void Send(byte[] data);
    public abstract EndPoint LocalEndPoint { get; }
    public abstract EndPoint RemoteEndPoint { get; }

    public virtual void Close()
    {
      _shouldAbort = true;
      _worker.Join(3000);
      if (_worker.ThreadState == ThreadState.Running) _worker.Interrupt();
      _worker = null;
    }

    #region IDisposable Members
    public void Dispose()
    {
      Close();
    }
    #endregion
  }
}
