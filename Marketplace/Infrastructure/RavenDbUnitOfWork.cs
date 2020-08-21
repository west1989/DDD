﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Framework;
using Raven.Client.Documents.Session;

namespace Marketplace.Infrastructure
{
  public class RavenDbUnitOfWork : IUnitOfWork
  {
    private readonly IAsyncDocumentSession _session;

    public RavenDbUnitOfWork(IAsyncDocumentSession session)
    {
      _session = session;
    }

    public Task Commit()
    {
      return _session.SaveChangesAsync();
    }
  }
}
