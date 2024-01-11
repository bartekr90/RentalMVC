using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity.DeviceEntities;

public class Node : BaseRentalEntity
{
    public required string Name { get; set; }
    public bool HasSubNodes { get; set; }
    public int? DeviceTypeId { get; set; }
    public virtual DeviceType? DeviceType { get; set; }
    public int? ParentNodeId { get; set; }
    public virtual Node? ParentNode { get; set; }
    public virtual ICollection<Node>? ChildNodes { get; set; }
}
