using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace CommLib
{
  public static class Delegates
  {
    public delegate void ExceptionDelegate(Exception ex);
    public delegate void TcpDataDelegate(TcpClient client, byte[] data);
    public delegate void TcpClientDelegate(TcpClient client);
    public delegate void ByteArrayDelegate(byte[] data);
  }
}
