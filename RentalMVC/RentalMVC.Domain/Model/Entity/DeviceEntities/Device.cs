using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity.DeviceEntities;

public class Device : BaseRentalEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; } //It tells whether the device counts in the collection of those available for rental. 
    public required string SerialNr { get; set; }
    public decimal? IndividualPrice { get; set; } //Overrides the price for the type 
    public int DeviceTypeId { get; set; }
    public virtual required DeviceType DeviceType { get; set; }
    public virtual ICollection<ReservationPosition>? Positions { get; set; }
}
