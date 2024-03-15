using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Application.ViewModels.Node;

public class NodeVm : IBaseVm, IAuditableVm, IBaseRentalVm
{
    public required string Name { get; set; }
    public bool HasSubNodes { get; set; }
    public int? DeviceTypeId { get; set; }
    public virtual DeviceTypeExtendedVm? DeviceType { get; set; }
    public int? ParentNodeId { get; set; }
    public virtual NodeVm? ParentNode { get; set; }
    public virtual ICollection<NodeVm>? ChildNodes { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
}
