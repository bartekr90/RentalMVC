using RentalMVC.Domain.Model.Common;
using RentalMVC.Domain.Model.Entity.DeviceEntities;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Model.Entity;

public class Rental : BaseEntity
{
    public required string Name { get; set; }
    public required int LessorId { get; set; }
    public virtual required Lessor Lessor { get; set; } 
    public int MainContactDataId { get; set; }
    public virtual required ContactData MainContactData { get; set; }
    public virtual ICollection<ContactData>? Contacts { get; set; }
    public virtual ICollection<Employee>? Employees { get; set; } 
    public virtual ICollection<Device>? Devices { get; set; }
    public virtual ICollection<DeviceType>? Types { get; set; }
    public virtual ICollection<Node>? Nodes { get; set; }
    public virtual ICollection<ReservationPosition>? Positions { get; set; }
    public virtual ICollection<Reservation>? Reservations { get; set; }
    public virtual ICollection<Client>? Clients { get; set; }
}