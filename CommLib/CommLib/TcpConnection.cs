using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CommLib
{
  public class TcpConnection : NetConnection
  {
    private TcpClient _client = null;

    public override EndPoint LocalEndPoint
    {
      get { return _client.Client.LocalEndPoint; }
    }

    public override EndPoint RemoteEndPoint
    {
      get { return _client.Client.RemoteEndPoint; }
    }

    public TcpConnection(TcpClient client, ConnectionDirection direction) : base(direction)
    {
      _client = client;
    }

    public static TcpConnection ConnectNew(IPAddress address, int port)
    {
      TcpClient client = new TcpClient();
      client.Connect(new IPEndPoint(address, port));
      TcpConnection conn = new TcpConnection(client, ConnectionDirection.Outbound);
      return conn;
    }

    public override void HandleConnection()
    {
      if (_client.Available > 0)
      {
        byte[] data = new byte[_client.Available];
        _client.Client.Receive(data);
        OnDataReceived(this, data);
      }
    }

    public override void Send(byte[] data)
    {
      _client.Client.Send(data);
    }

    public override void  Close()
    {
 	     base.Close();
       _client.Close();
    }
  }
}
