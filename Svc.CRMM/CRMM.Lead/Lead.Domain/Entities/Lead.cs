namespace Lead.Domain.Entities;

public sealed class Lead
{
    public Guid Id { get; private set; }
    public string LeadNo { get; private set; }

    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? CompanyName { get; private set; }

    public string? Email { get; private set; }
    public string? Phone { get; private set; }

    public Enums.LeadStatus Status { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    private Lead() { }

    public Lead(
        Guid id,
        string leadNo,
        string? firstName,
        string? lastName,
        string? companyName,
        string? email,
        string? phone,
        Enums.LeadStatus status,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        LeadNo = leadNo;
        FirstName = firstName;
        LastName = lastName;
        CompanyName = companyName;
        Email = email;
        Phone = phone;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public void UpdateBasics(
        string? firstName,
        string? lastName,
        string? companyName,
        string? email,
        string? phone,
        Enums.LeadStatus status,
        DateTimeOffset updatedAt)
    {
        FirstName = firstName;
        LastName = lastName;
        CompanyName = companyName;
        Email = email;
        Phone = phone;
        Status = status;
        UpdatedAt = updatedAt;
    }
}
