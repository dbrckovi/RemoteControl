using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommLib
{
  public class InvalidNetMessageException : Exception
  {
    public InvalidNetMessageException(string message) : base(message) { }
  }
}
