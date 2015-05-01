using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommLib
{
  public class TcpManager
  {
    #region Variables
    private int _listeningPort = -1;
    TcpListener _listener = null;
    private Thread _worker = null;
    private bool _shouldStop = true;
    private List<TcpClient> _clients = new List<TcpClient>();
    #endregion Variables

    #region Properties
    public int ListeningPort
    {
      get { return _listeningPort; }
    }
    #endregion Properties

    #region Events
    public event Delegates.ExceptionDelegate ExceptionOccured;
    private void OnExceptionOccured(Exception ex)
    {
      if (ExceptionOccured != null) ExceptionOccured(ex);
    }

    public event Delegates.TcpDataDelegate TcpDataReceived;
    private void OnTcpDataReceived(TcpClient client, byte[] data)
    {
      if (TcpDataReceived != null) TcpDataReceived(client, data);
    }

    public event Delegates.TcpClientDelegate TcpClientConnected;
    private void OnTcpClientConnected(TcpClient client)
    {
      if (TcpClientConnected != null) TcpClientConnected(client);
    }
    #endregion Events

    #region Constructor
    public TcpManager(int listeningPort)
    {
      _listeningPort = listeningPort;
      _listener = new TcpListener(IPAddress.Any,listeningPort);
      _listener.Start();

      _shouldStop = false;
      ThreadStart start = new ThreadStart(Work);
      _worker = new Thread(start);
      _worker.Start();
    }
    #endregion Constructor

    #region Methods
    /// <summary>
    /// Closes all network connections, listeners and stops all threads
    /// </summary>
    public void Close()
    {
      _listener.Stop();

      //For now, this closes all clients, but when control messages are implemented...
      //TODO: mark each client as Inbound/Outbound and close all outbound first, wait for a moment, and then close remaining inbound
      foreach (TcpClient client in _clients)
      {
        client.Close();
      }

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
          #region Handle listener
          if (_listener.Pending())
          {
            TcpClient newClient = _listener.AcceptTcpClient();
            _clients.Add(newClient);
            OnTcpClientConnected(newClient);
          }
          #endregion Handle listener

          #region Handle connections
          foreach (TcpClient client in _clients)
          {
            if (client.Available > 0)
            {
              byte[] data = new byte[client.Available];
              client.Client.Receive(data);
              OnTcpDataReceived(client, data);
            }
          }
          #endregion Handle connections

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

    public void Connect(IPAddress address, int port)
    {
      TcpClient client = new TcpClient();
      client.Connect(new IPEndPoint(address, port));
      _clients.Add(client);
      OnTcpClientConnected(client);
    }
    #endregion Methods
  }
}
