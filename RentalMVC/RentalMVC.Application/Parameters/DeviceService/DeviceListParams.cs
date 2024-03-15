using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.DeviceService;

public class DeviceListParams
{
    public int RentalId { get; set; }
    public int TypeId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public RentalId GetRentalId => new(RentalId);
    public DeviceTypeId GetTypeId => new(TypeId);
}
