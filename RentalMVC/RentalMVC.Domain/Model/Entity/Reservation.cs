using RentalMVC.Domain.Model.Common;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Model.Entity;

public class Reservation : BaseRentalEntity
{    
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public required string ClientName { get; set; }
    public required string RentalName { get; set; }
    public required string Title { get; set; }
    public bool IsOwnedByCustomer { get; set; } // Says whether the equipment is in the customer's possession
    public string? Comments { get; set; }
    public decimal Value { get; set; }
    public int ClientId { get; set; }
    public virtual required Client Client { get; set; }
    public virtual required ICollection<ReservationPosition> Positions { get; set; }
}