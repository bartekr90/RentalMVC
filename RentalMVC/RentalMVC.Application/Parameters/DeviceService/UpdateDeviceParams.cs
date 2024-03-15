using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.DeviceService;

public class UpdateDeviceParams
{
    public required EditDeviceVm ViewModel { get; set; }
    public required string UserId { get; set; }
    public int RentalId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public RentalId GetRentalId => new(RentalId);
    public UserId GetUserId => new(UserId);

}
