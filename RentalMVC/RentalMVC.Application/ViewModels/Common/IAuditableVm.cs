namespace RentalMVC.Application.ViewModels.Common;

public interface IAuditableVm
{
    public string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
