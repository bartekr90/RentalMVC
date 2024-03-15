using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Tests.SampleData.DeviceTypeSample.VMs;

internal class ListDeviceTypeVmSample
{
    public static ListDeviceTypeVm[] GetListDeviceTypeVmSampleByRental =>
        new ListDeviceTypeVm[]
        {
            new()
            {
                Types = GetDeviceTypeVmSampleWithRentalId2.ToList(),
                Count = 3
            },
            new()
            {
                Types = GetDeviceTypeVmSampleWithRentalId1.ToList(),
                Count = 2
            }
        };       
}


