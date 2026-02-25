using System.Collections.Concurrent;
using LeadEntity = Lead.Domain.Entities.Lead;
using Lead.Domain.Repositories;

namespace Lead.Api.ConnectedSource.Repositories;

public sealed class InMemoryLeadRepository : ILeadRepository
{
    private readonly ConcurrentDictionary<Guid, LeadEntity> _store = new();

    public Task AddAsync(LeadEntity lead, CancellationToken cancellationToken)
    {
        _store[lead.Id] = lead;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        _store.TryRemove(id, out _);
        return Task.CompletedTask;
    }

    public Task<LeadEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _store.TryGetValue(id, out var lead);
        return Task.FromResult(lead);
    }

    public Task<IReadOnlyList<LeadEntity>> ListAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<LeadEntity> items = _store.Values.OrderByDescending(x => x.CreatedAt).ToList();
        return Task.FromResult(items);
    }

    public Task UpdateAsync(LeadEntity lead, CancellationToken cancellationToken)
    {
        _store[lead.Id] = lead;
        return Task.CompletedTask;
    }
}
