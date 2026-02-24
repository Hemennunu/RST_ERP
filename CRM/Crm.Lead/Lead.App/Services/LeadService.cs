using Lead.App.Dtos;
using Lead.Domain.Entities;
using Lead.Domain.Enums;
using Lead.Domain.Repositories;
using Lead.Utilities;

namespace Lead.App.Services;

public sealed class LeadService
{
    private readonly ILeadRepository _repo;

    public LeadService(ILeadRepository repo)
    {
        _repo = repo;
    }

    public async Task<IReadOnlyList<LeadDto>> ListAsync(CancellationToken cancellationToken)
    {
        var items = await _repo.ListAsync(cancellationToken);
        return items.Select(ToDto).ToList();
    }

    public async Task<LeadDto?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var lead = await _repo.GetByIdAsync(id, cancellationToken);
        return lead is null ? null : ToDto(lead);
    }

    public async Task<LeadDto> CreateAsync(CreateLeadRequest request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        var lead = new Lead(
            id: Guid.NewGuid(),
            leadNo: LeadNoGenerator.NewLeadNo(now),
            firstName: request.FirstName,
            lastName: request.LastName,
            companyName: request.CompanyName,
            email: request.Email,
            phone: request.Phone,
            status: request.Status ?? LeadStatus.New,
            createdAt: now,
            updatedAt: now);

        await _repo.AddAsync(lead, cancellationToken);
        return ToDto(lead);
    }

    public async Task<LeadDto?> UpdateAsync(Guid id, UpdateLeadRequest request, CancellationToken cancellationToken)
    {
        var lead = await _repo.GetByIdAsync(id, cancellationToken);
        if (lead is null)
        {
            return null;
        }

        var now = DateTimeOffset.UtcNow;
        lead.UpdateBasics(
            firstName: request.FirstName,
            lastName: request.LastName,
            companyName: request.CompanyName,
            email: request.Email,
            phone: request.Phone,
            status: request.Status,
            updatedAt: now);

        await _repo.UpdateAsync(lead, cancellationToken);
        return ToDto(lead);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var lead = await _repo.GetByIdAsync(id, cancellationToken);
        if (lead is null)
        {
            return false;
        }

        await _repo.DeleteAsync(id, cancellationToken);
        return true;
    }

    private static LeadDto ToDto(Lead lead) => new(
        lead.Id,
        lead.LeadNo,
        lead.FirstName,
        lead.LastName,
        lead.CompanyName,
        lead.Email,
        lead.Phone,
        lead.Status,
        lead.CreatedAt,
        lead.UpdatedAt);
}
