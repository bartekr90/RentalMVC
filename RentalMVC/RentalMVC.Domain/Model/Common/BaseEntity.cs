namespace RentalMVC.Domain.Model.Common;

public class BaseEntity : AuditableModel
{
    public int Id { get; set; }
    public bool Active { get; set; } //Allows operations on the object, controlled by the users. 
    public bool Deleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}