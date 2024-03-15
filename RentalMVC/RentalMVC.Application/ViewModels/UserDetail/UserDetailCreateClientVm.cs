using RentalMVC.Application.ViewModels.Client;
using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.UserDetail;

public class UserDetailCreateClientVm : IBaseVm, IAuditableVm
{
    public required NewClientVm NewClient { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
