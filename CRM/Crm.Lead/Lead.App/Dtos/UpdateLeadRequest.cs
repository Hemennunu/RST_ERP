using Lead.Domain.Enums;

namespace Lead.App.Dtos;

public sealed record UpdateLeadRequest(
    string? FirstName,
    string? LastName,
    string? CompanyName,
    string? Email,
    string? Phone,
    LeadStatus Status);
