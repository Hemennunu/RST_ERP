using System.Collections.Concurrent;
using Lead.Domain.Entities;
using Lead.Domain.Repositories;

namespace Lead.Api.Repositories;

public sealed class InMemoryLeadRepository : ILeadRepository
{
    private readonly ConcurrentDictionary<Guid, Lead> _store = new();

    public Task AddAsync(Lead lead, CancellationToken cancellationToken)
    {
        _store[lead.Id] = lead;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        _store.TryRemove(id, out _);
        return Task.CompletedTask;
    }

    public Task<Lead?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _store.TryGetValue(id, out var lead);
        return Task.FromResult(lead);
    }

    public Task<IReadOnlyList<Lead>> ListAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<Lead> items = _store.Values.OrderByDescending(x => x.CreatedAt).ToList();
        return Task.FromResult(items);
    }

    public Task UpdateAsync(Lead lead, CancellationToken cancellationToken)
    {
        _store[lead.Id] = lead;
        return Task.CompletedTask;
    }
}
