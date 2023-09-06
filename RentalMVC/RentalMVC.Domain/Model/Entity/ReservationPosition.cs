using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity;

public class ReservationPosition : BaseEntity
{
    public int SequenceNumber { get; set; }
    public int EquipmentQuantity { get; set; }
    public decimal Value { get; set; }
    public int DeviceId { get; set; }
    public int ReservationId { get; set; }
    public int DeviceTypeId { get; set; }
    public virtual required Device Device { get; set; }
    public virtual required Reservation Reservation { get; set; }
    public virtual required DeviceType DeviceType { get; set; }
}