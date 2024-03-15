using RentalMVC.Domain.Model.Common;
using RentalMVC.Domain.Model.Entity.DeviceEntities;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Model.Entity;

public class ReservationPosition : BaseRentalEntity
{
    public int SequenceNumber { get; set; }
    public int TimeUnits { get; set; }
    public decimal Value { get; set; }
    public int DeviceId { get; set; }
    public virtual required Device Device { get; set; }
    public int ReservationId { get; set; }
    public virtual required Reservation Reservation { get; set; }
    public int DeviceTypeId { get; set; }
    public virtual required DeviceType DeviceType { get; set; }
    public int ClientId { get; set; }
    public virtual required Client Client { get; set; }
}