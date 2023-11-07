using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity;

public class Node : BaseEntity
{
    public required string Name { get; set; }
    public bool HasSubNodes { get; set; }
    public int? DeviceTypeId { get; set; }
    public int? ParentNodeId { get; set; }
    public virtual required DeviceType DeviceType { get; set; }
    public virtual required Node ParentNode { get; set; }
    public virtual ICollection<Node> ChildNodes { get; set; } = new List<Node>();
}
