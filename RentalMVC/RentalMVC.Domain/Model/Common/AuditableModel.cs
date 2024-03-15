namespace RentalMVC.Domain.Model.Common;

public class AuditableModel
{
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
