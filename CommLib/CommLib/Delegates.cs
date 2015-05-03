using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace CommLib
{
  public static class Delegates
  {
    public delegate void VoidDelegate();
    public delegate void ExceptionDelegate(Exception ex);
    public delegate void NetDataDelegate(NetConnection client, byte[] data);
    public delegate void NetConnectionDelegate(NetConnection client);
    public delegate void ByteArrayDelegate(byte[] data);
  }
}
