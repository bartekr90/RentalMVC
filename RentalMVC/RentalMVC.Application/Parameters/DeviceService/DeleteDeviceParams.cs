using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.DeviceService;

public class DeleteDeviceParams
{
    public required DeviceExtendedVm ViewModel { get; set; }
    public required string UserId { get; set; }
    public int RentalId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public UserId GetUserId => new(UserId);
    public RentalId GetRentalId => new(RentalId);
}
