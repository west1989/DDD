﻿using System;
using System.Collections.Generic;
using System.Text;
using Marketplace.Framework;

namespace Marketplace.Domain
{
  public class UserId
  {
    private Guid Value { get; set; }

    public UserId(Guid value)
    {
      if (value == default)
        throw new ArgumentNullException(nameof(value), "User id cannot be empty");

      Value = value;
    }

    public static implicit operator Guid(UserId self) => self.Value;
  }
}
