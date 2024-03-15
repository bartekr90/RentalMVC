using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.DeviceService;

public class DeviceParams
{
    public int DeviceId { get; set; }
    public int RentalId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public DeviceId GetDeviceId => new(DeviceId);
    public RentalId GetRentalId => new(RentalId);
}
