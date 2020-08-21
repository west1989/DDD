using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Framework
{
  public static class StringTools
  {
    public static bool IsEmpty(this string value)
    {
      return string.IsNullOrWhiteSpace(value);
    }
  }
}
