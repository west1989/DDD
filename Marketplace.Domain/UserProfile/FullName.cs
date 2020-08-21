using System;
using System.Collections.Generic;
using System.Text;
using Marketplace.Framework;

namespace Marketplace.Domain.UserProfile
{
  public class FullName : Value<FullName>
  {
    public string Value { get; }

    internal FullName(string fullName)
    {
      Value = fullName;
    }

    public static FullName FromString(string fullName)
    {
      if (fullName.IsEmpty())
        throw new ArgumentNullException(nameof(fullName));

      return new FullName(fullName);
    }

    public static implicit operator string(FullName fullName)
    {
      return fullName.Value;
    }
      
    // Satisfy the serialization requirements
    protected FullName() { }
  }
}
