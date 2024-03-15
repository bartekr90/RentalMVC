using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Application.ViewModels.Device;

public class EditDeviceVm : IBaseVm, IAuditableVm, IBaseRentalVm
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public required string SerialNr { get; set; }
    public decimal? IndividualPrice { get; set; }
    public bool IsOnPositions { get; set; }
    public int DeviceTypeId { get; set; }
    public required DeviceTypeVm DeviceTypeVm { get; set; }
    public ListDeviceTypeVm? TypesListVm { get; set; }
    public required ListPositionVm PositionsVm { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
}
