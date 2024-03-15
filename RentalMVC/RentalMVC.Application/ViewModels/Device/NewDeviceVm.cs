using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Application.ViewModels.Device;

public class NewDeviceVm  
{
    public required string Name { get; set; }
    public int RentalId { get; set; }
    public string? Description { get; set; }
    public required string SerialNr { get; set; }
    public decimal? IndividualPrice { get; set; }
    public int DeviceTypeId { get; set; }
    public string? UserId { get; set; }
    public bool IsActive { get; set; }
    public required ListDeviceTypeVm ListOfDeviceTypeVm { get; set; }
}
