using Lead.Domain.Enums;

namespace Lead.Domain.DTO;

public sealed record CreateLeadRequest(
    string? FirstName,
    string? LastName,
    string? CompanyName,
    string? Email,
    string? Phone,
    LeadStatus? Status);
