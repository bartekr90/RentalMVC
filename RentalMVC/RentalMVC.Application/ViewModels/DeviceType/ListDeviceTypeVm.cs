namespace RentalMVC.Application.ViewModels.DeviceType;

public class ListDeviceTypeVm 
{
    public List<DeviceTypeVm> Types { get; set; } = new List<DeviceTypeVm>();
    public int Count { get; set; }
}