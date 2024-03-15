namespace RentalMVC.Application.ViewModels.DeviceType;

public class NewDeviceTypeVm
{
    public bool Active { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int NodeId { get; set; }
}
