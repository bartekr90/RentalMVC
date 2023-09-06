namespace RentalMVC.Domain.Model.Common;

public class AuditableModel
{
    public required string CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public required string ModifiedBy { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }

}

