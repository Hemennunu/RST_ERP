using Lead.Domain.Entities;

namespace Lead.Domain.Repositories;

public interface ILeadRepository
{
    Task<Lead?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Lead>> ListAsync(CancellationToken cancellationToken);
    Task AddAsync(Lead lead, CancellationToken cancellationToken);
    Task UpdateAsync(Lead lead, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
