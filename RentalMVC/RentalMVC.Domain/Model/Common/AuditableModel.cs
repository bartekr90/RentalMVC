namespace RentalMVC.Domain.Model.Common;

public class AuditableModel
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }

}
//public class AuditableModel
//{
//    public required string CreatedBy { get; set; }
//    public DateTimeOffset CreatedAt { get; set; }
//    public string? ModifiedBy { get; set; }
//    public DateTimeOffset? ModifiedAt { get; set; }

//}

