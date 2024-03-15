using RentalMVC.Application.ViewModels.Device;

namespace RentalMVC.Tests.SampleData.DeviceSample.VMs;

internal static class ListDeviceVmSample
{
    public static ListDeviceVm[] ListDeviceVmSampleWithRentalId1 =>
         new ListDeviceVm[]
         {
            new ()
            {
                Devices = GetDeviceVmSampleRentalId1TypeId1.ToList(),
                Count = 5
            },
            new ()
            {
                Devices = GetDeviceVmSampleRentalId1TypeId2.ToList(),
                Count = 4
            }
         }; 

    public static ListDeviceVm[] ListDeviceVmSampleWithRentalId2 =>
         new ListDeviceVm[]
         {
            new ()
            {
                Devices = GetDeviceVmSampleRentalId2TypeId5.ToList(),
                Count = 3
            },
            new ()
            {
                Devices = GetDeviceVmSampleRentalId2TypeId4.ToList(),
                Count = 3
            }
         };
}

