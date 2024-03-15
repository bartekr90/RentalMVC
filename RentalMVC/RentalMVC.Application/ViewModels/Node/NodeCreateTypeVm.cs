using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Application.ViewModels.Node;

public class NodeCreateTypeVm : IBaseVm, IAuditableVm, IBaseRentalVm
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string Name { get; set; }
    public bool HasSubNodes { get; set; }
    public virtual NewDeviceTypeVm? DeviceType { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
}
