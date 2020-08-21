using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace
{
  public static class Exceptions
  {
    public class DuplicatedEntityIdException : Exception
    {
      public DuplicatedEntityIdException(string message) : base(message)
      {
      }
    }
  }
}
