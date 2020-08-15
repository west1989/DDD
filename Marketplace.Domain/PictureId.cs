﻿using System;
using System.Collections.Generic;
using System.Text;
using Marketplace.Framework;

namespace Marketplace.Domain
{
  public class PictureId : Value<PictureId>
  {
    public PictureId(Guid value) => Value = value;

    public Guid Value { get; }
  }
}
