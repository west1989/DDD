using System;
using System.Threading.Tasks;
using Marketplace.Domain.ClassifiedAd;
using Raven.Client.Documents.Session;

namespace Marketplace.ClassifiedAd
{
  public class ClassifiedAdRepository : IClassifiedAdRepository, IDisposable
  {
    private readonly IAsyncDocumentSession _session;

    public ClassifiedAdRepository(IAsyncDocumentSession session)
    {
      _session = session;
    }

    public Task<bool> Exists(ClassifiedAdId id)
    {
      return _session.Advanced.ExistsAsync(EntityId(id));
    }

    public Task<Domain.ClassifiedAd.ClassifiedAd> Load(ClassifiedAdId id)
    {
      return _session.LoadAsync<Domain.ClassifiedAd.ClassifiedAd>(EntityId(id));
    }

    public Task Add(Domain.ClassifiedAd.ClassifiedAd entity)
    {
      return _session.StoreAsync(entity, EntityId(entity.Id));
    }

    public void Dispose()
    {
      _session?.Dispose();
    }

    private static string EntityId(ClassifiedAdId id)
    {
      return $"ClassifiedAd/{id.ToString()}";
    }
  }
}
