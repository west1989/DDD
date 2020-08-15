﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.Framework
{
  public abstract class Entity<TId> : IInternalEventHandler where TId : Value<TId>
  {
    private readonly Action<object> _applier;
    public TId Id { get; protected set; }

    protected Entity(Action<Object> applier) => _applier = applier;
    
    protected void Apply(object @event)
    {
      When(@event);
      _applier(@event);
    }

    protected abstract void When(object @event);

    void IInternalEventHandler.Handle(object @event) => When(@event);
  }
}
