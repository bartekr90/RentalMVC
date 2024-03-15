namespace RentalMVC.Application.ViewModels.DeviceType;

public class ListDeviceTypeExtendedVm 
{
    public List<DeviceTypeExtendedVm> Types { get; set; } = new List<DeviceTypeExtendedVm>();
    public int Count { get; set; }
}
