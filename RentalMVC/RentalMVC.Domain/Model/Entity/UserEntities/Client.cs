using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity.UserEntities;

public class Client : BaseEntity
{
    public required string Name { get; set; }
    public int MainContactDataId { get; set; }
    public virtual ContactData? MainContactData { get; set; }
    public int UserDetailId { get; set; }
    public required virtual UserDetail UserDetail { get; set; }
    public virtual ICollection<ContactData>? Contacts { get; set; }
    public virtual ICollection<ReservationPosition>? Positions { get; set; }
    public virtual ICollection<Reservation>? Reservations { get; set; }
}