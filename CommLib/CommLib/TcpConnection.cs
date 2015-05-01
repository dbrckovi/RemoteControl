using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommLib
{
  public class TcpConnection
  {
    private int _listeningPort = -1;
    TcpListener _listener = null;

    private Thread _worker = null;
    private bool _shouldStop = true;

    #region Events
    public event Delegates.ExceptionDelegate ExceptionOccured;
    private void OnExceptionOccured(Exception ex)
    {
      if (ExceptionOccured != null) ExceptionOccured(ex);
    }
    #endregion Events

    #region Constructor
    public TcpConnection(int listeningPort)
    {
      _listener = new TcpListener(IPAddress.Any,listeningPort);
      _listener.Start();

      _shouldStop = false;
      ThreadStart start = new ThreadStart(Work);
      _worker.Start();


    }
    #endregion Constructor


    /// <summary>
    /// Closes all network connections, listeners and stops all threads
    /// </summary>
    private void Close()
    {
      _listener.Stop();
      //TODO: close all connections
      _shouldStop = true;
      _worker.Join(3000);
      if (_worker.ThreadState == ThreadState.Running) _worker.Interrupt();
      _worker = null;
    }

    private void Work()
    {
      while (!_shouldStop)
      {
        try
        {
          Thread.Sleep(1);
        }
        catch (ThreadInterruptedException)
        {
          return;
        }
        catch (Exception ex)
        {
          OnExceptionOccured(ex);
        }
      }
    }
  }
}
