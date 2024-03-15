using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.ReservationPosition;

public class PositionExtendedVm : IBaseVm
{
    public int SequenceNumber { get; set; }
    public int EquipmentQuantity { get; set; }
    public decimal Value { get; set; }
    public int DeviceId { get; set; }
    public required string DeviceName { get; set; }
    public int ReservationId { get; set; }
    public required string ReservationName { get; set; }
    public int DeviceTypeId { get; set; }
    public required string DeviceTypeName { get; set; }
    public int ClientId { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}