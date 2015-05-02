using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommLib
{
  /// <summary>
  /// Holds reference to all connections, creates new connections, closes connections, manages all connection listeners
  /// </summary>
  public class ConnectionManager : IDisposable
  {
    #region Variables
    private int _listeningPort = -1;
    TcpListener _listener = null;
    private Thread _worker = null;
    private bool _shouldAbort = true;
    private List<NetConnection> _connections = new List<NetConnection>();
    #endregion Variables

    #region Properties
    public int ListeningPort
    {
      get { return _listeningPort; }
    }
    #endregion Properties

    #region Events
    /// <summary>
    /// Raised when unhandled exception occurs in any thread
    /// </summary>
    public event Delegates.ExceptionDelegate ExceptionOccured;
    private void OnExceptionOccured(Exception ex)
    {
      if (ExceptionOccured != null) ExceptionOccured(ex);
    }

    /// <summary>
    /// Raised when data is received on any connection
    /// </summary>
    public event Delegates.NetDataDelegate NetDataReceived;
    private void OnNetDataReceived(NetConnection connection, byte[] data)
    {
      if (NetDataReceived != null) NetDataReceived(connection, data);
    }

    /// <summary>
    /// Raised when any connection has been established and added to list of connections
    /// </summary>
    public event Delegates.NetConnectionDelegate ConnectionEstablished;
    private void OnConnectionEstablished(NetConnection connection)
    {
      connection.DataReceived += new Delegates.NetDataDelegate(connection_DataReceived);
      connection.ExceptionOccured += new Delegates.ExceptionDelegate(connection_ExceptionOccured);
      if (ConnectionEstablished != null) ConnectionEstablished(connection);
    }
    #endregion Events

    #region Constructor
    public ConnectionManager(int listeningPort)
    {
      _listeningPort = listeningPort;
      _listener = new TcpListener(IPAddress.Any,listeningPort);
      _listener.Start();

      _shouldAbort = false;
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
      foreach (NetConnection connection in _connections)
      {
        connection.Close();
      }

      _shouldAbort = true;
      _worker.Join(3000);
      if (_worker.ThreadState == ThreadState.Running) _worker.Interrupt();
      _worker = null;
    }

    /// <summary>
    /// Periodically handles new connections on all listeners
    /// </summary>
    private void Work()
    {
      while (!_shouldAbort)
      {
        try
        {
          #region Handle listener
          if (_listener.Pending())
          {
            TcpClient newClient = _listener.AcceptTcpClient();
            NetConnection newConnection = new TcpConnection(newClient, ConnectionDirection.Inbound);
            _connections.Add(newConnection);
            OnConnectionEstablished(newConnection);
          }
          #endregion Handle listener
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

    /// <summary>
    /// Establishes a new TcpConnection to specified remote address and port
    /// </summary>
    /// <param name="address"></param>
    /// <param name="port"></param>
    public void TcpConnect(IPAddress address, int port)
    {
      NetConnection newConnection = TcpConnection.ConnectNew(address, port);
      _connections.Add(newConnection);
      OnConnectionEstablished(newConnection);
    }
    #endregion Methods

    void connection_ExceptionOccured(Exception ex)
    {
      OnExceptionOccured(ex);
    }

    void connection_DataReceived(NetConnection client, byte[] data)
    {
      OnNetDataReceived(client, data);
    }

    #region IDisposable Members
    public void Dispose()
    {
      Close();
    }
    #endregion
  }
}
