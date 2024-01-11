using RentalMVC.Domain.Model.Common;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Model.Entity.UserEntities;

public class Lessor : BaseEntity
{
    public required string Name { get; set; }
    public required string UserId { get; set; }
    public bool CanLaunchRental { get; set; }
    public int? RentalId { get; set; }
    public virtual Rental? Rental { get; set; }
    public int? MainContactDataId { get; set; }
    public virtual ContactData? MainContactData { get; set; }
    public int UserDetailId { get; set; }
    public required virtual UserDetail UserDetail { get; set; }
    public virtual ICollection<ContactData>? Contacts { get; set; }
    public virtual ICollection<Device>? Devices { get; set; }
    public virtual ICollection<DeviceType>? Types { get; set; }
    public virtual ICollection<Node>? Nodes { get; set; }
}