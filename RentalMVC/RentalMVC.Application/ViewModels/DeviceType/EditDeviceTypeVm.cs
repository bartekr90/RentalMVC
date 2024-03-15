using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.Node;
using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Application.ViewModels.DeviceType;

public class EditDeviceTypeVm : IBaseVm, IAuditableVm, IBaseRentalVm
{
    public required string Name { get; set; }
    public required string FullPath { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool HasDevices { get; set; }
    public required ListDeviceExtendedVm Devices { get; set; }
    public int NodeId { get; set; }
    public required NodeForListVm Node { get; set; }
    public required ListPositionExtendedVm Positions { get; set; }
    public bool IsOnPositions { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
}
