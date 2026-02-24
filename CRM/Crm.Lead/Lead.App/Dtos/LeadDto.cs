using Lead.Domain.Enums;

namespace Lead.App.Dtos;

public sealed record LeadDto(
    Guid Id,
    string LeadNo,
    string? FirstName,
    string? LastName,
    string? CompanyName,
    string? Email,
    string? Phone,
    LeadStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
