using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.ReservationPosition;

public class PositionVm : IBaseVm, IAuditableVm
{
    public int SequenceNumber { get; set; }
    public int TimeUnits { get; set; }
    public decimal Value { get; set; }
    public int DeviceId { get; set; }
    public string? DeviceName { get; set; }
    public int ReservationId { get; set; }
    public int DeviceTypeId { get; set; }
    public string? DeviceTypeName { get; set; }
    public int ClientId { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public int RentalId { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}