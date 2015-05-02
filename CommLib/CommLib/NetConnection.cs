using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace CommLib
{
  /// <summary>
  /// Base class for all connections. Used for sending and receiving data from a single connection
  /// </summary>
  public abstract class NetConnection : IDisposable
  {
    private ConnectionDirection _direction = ConnectionDirection.Inbound;
    private Thread _worker = null;
    private bool _shouldAbort = true;

    /// <summary>
    /// Raised when exception occurs in underlaying thread
    /// </summary>
    public event Delegates.ExceptionDelegate ExceptionOccured;
    private void OnExceptionOccured(Exception ex)
    {
      if (ExceptionOccured != null) ExceptionOccured(ex);
    }

    /// <summary>
    /// Raised when data is received
    /// </summary>
    public event Delegates.NetDataDelegate DataReceived;
    internal void OnDataReceived(NetConnection client, byte[] data)
    {
      if (DataReceived != null) DataReceived(client, data);
    }

    /// <summary>
    /// Designates the direction in which the connection was initiated
    /// </summary>
    public ConnectionDirection Direction
    {
      get { return _direction; }
    }

    /// <summary>
    /// Initiates a new connection in specified direction and starts the connection handling thread
    /// </summary>
    /// <param name="direction"></param>
    public NetConnection(ConnectionDirection direction)
    {
      _direction = direction;
      ThreadStart start = new ThreadStart(ThreadWorker);
      _worker = new Thread(start);
      _shouldAbort = false;
      _worker.Start();
    }

    /// <summary>
    /// Periodically HandleConnection() method
    /// </summary>
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

    /// <summary>
    /// Stops the thread, and when overriden in derived class, closes the connection
    /// </summary>
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
