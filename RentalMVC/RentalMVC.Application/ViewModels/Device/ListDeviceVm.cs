namespace RentalMVC.Application.ViewModels.Device;

public class ListDeviceVm 
{
    public List<DeviceVm> Devices { get; set; } = new List<DeviceVm>();
    public int Count { get; set; }
}