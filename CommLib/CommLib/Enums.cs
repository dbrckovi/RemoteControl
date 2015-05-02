using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommLib
{
  /// <summary>
  /// Designates the direction in which the connecton was initiated
  /// </summary>
  public enum ConnectionDirection
  {
    /// <summary>
    /// Connection was initiated from remote location
    /// </summary>
    Inbound = 0,
    /// <summary>
    /// Connection was initiated from this location
    /// </summary>
    Outbound = 1
  }
}
