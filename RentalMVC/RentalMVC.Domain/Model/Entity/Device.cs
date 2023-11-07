using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity;

public class Device : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public required string SerialNr { get; set; }
    public decimal IndividualPrice { get; set; }
    public int DeviceTypeId { get; set; }
    public virtual required DeviceType DeviceType { get; set; }
    public virtual ICollection<ReservationPosition> Positions { get; set; } = new List<ReservationPosition>();

}
