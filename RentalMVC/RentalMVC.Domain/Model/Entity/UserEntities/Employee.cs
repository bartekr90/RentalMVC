using RentalMVC.Domain.Model.Common;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Model.Entity.UserEntities;

public class Employee : BaseRentalEntity
{
    public required string UserId { get; set; }
    public required string Name { get; set; }
    public int UserDetailId { get; set; }
    public required virtual UserDetail UserDetail { get; set; }
    public int MainContactDataId { get; set; }
    public virtual ContactData? MainContactData { get; set; }
    public virtual ICollection<Device>? Devices { get; set; }
    public virtual ICollection<DeviceType>? Types { get; set; }
    public virtual ICollection<Node>? Nodes { get; set; }
}