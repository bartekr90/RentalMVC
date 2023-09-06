using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity;

public class Reservation : BaseEntity
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public required string CustomerName { get; set; }
    public required string CustomerContact { get; set; }
    public required string Title { get; set; }
    public required string Comments { get; set; }
    public decimal Value { get; set; }
    public virtual ICollection<ReservationPosition> Positions { get; set; } = new List<ReservationPosition>();
}
