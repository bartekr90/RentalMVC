using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Application.ViewModels.ReservationPosition;
public class NewPositionVm
{
    public bool Active { get; set; }
    public int SequenceNumber { get; set; }
    public int EquipmentQuantity { get; set; }
    public decimal Value { get; set; }
    public int DeviceId { get; set; }
    public required ListDeviceExtendedVm Device { get; set; }
    public int ReservationId { get; set; }
    public int DeviceTypeId { get; set; }
    public required ListDeviceTypeExtendedVm DeviceType { get; set; }
    public int ClientId { get; set; }
}