using LeadEntity = Lead.Domain.Entities.Lead;

namespace Lead.Domain.Repositories;

public interface ILeadRepository
{
    Task<LeadEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<LeadEntity>> ListAsync(CancellationToken cancellationToken);
    Task AddAsync(LeadEntity lead, CancellationToken cancellationToken);
    Task UpdateAsync(LeadEntity lead, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
