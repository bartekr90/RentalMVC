using RentalMVC.Application.ViewModels.Client;
using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Application.ViewModels.ReservationPosition;

public class EditPositionVm : IBaseVm, IBaseRentalVm, IAuditableVm
{
    public int SequenceNumber { get; set; }
    public int EquipmentQuantity { get; set; }
    public decimal Value { get; set; }
    public int DeviceId { get; set; }
    public required DeviceExtendedVm Device { get; set; }
    public int ReservationId { get; set; }
    public required ReservationForListVm Reservation { get; set; }
    public int DeviceTypeId { get; set; }
    public required DeviceTypeExtendedVm DeviceType { get; set; }
    public int ClientId { get; set; }
    public required ClientForListVm Client { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
