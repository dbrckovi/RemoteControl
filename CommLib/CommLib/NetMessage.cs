using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommLib
{
  public class NetMessage
  {
    private NetMessageType _messageType = NetMessageType.None;
    private byte[] _rawData = null;
    private byte[] _rawValue = null;

    #region Properties
    /// <summary>
    /// Gets type of the message
    /// </summary>
    public NetMessageType MessageType
    {
      get { return _messageType; }
    }

    /// <summary>
    /// Gets all bytes of the raw message
    /// </summary>
    public byte[] RawData
    {
      get { return _rawData; }
    }

    /// <summary>
    /// Gets only data part of the real message (without the prefix designating message type)
    /// </summary>
    public byte[] RawValue
    {
      get { return _rawValue; }
    }
    #endregion Properties

    public NetMessage(byte[] rawData)
    {
      _rawData = rawData;
      if (_rawData == null || _rawData.Length == 0) throw new InvalidNetMessageException("Message is null or empty");

      try
      {
        _messageType = (NetMessageType)_rawData[0];
      }
      catch 
      {
        throw new InvalidNetMessageException("Message type not recognized");
      }
    
      //TODO: finish
    }
  }

  public enum NetMessageType
  {
    None = 0,
    PingRequest = 1,
    PingResponse = 2,
    Disconnect = 3
  }
}
