using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.DeviceService;

public class NewDeviceParams
{
    public int RentalId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public RentalId GetRentalId => new(RentalId);
}
