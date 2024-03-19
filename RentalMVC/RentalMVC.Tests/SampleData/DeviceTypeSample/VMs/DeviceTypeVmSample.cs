using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Tests.SampleData.DeviceTypeSample.VMs;
internal class DeviceTypeVmSample
{
    public static DeviceTypeVm GetNewDeviceTypeVm =>
        new()
        { 
            CreatorId = "",
            FullPath = string.Empty,
            Name = string.Empty,            
        };
    public static DeviceTypeVm[] GetDeviceTypeVmSampleWithRentalId1 =>
        new DeviceTypeVm[2]
        {
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[0],
                Id = 1,
                Active = true,
                Name = "Wiertarki",
                NodeId = 1,
                FullPath = "MainFolder/",
                RentalId = 1,
                Price = 10,
                HasDevices = true,
                TotalDevices = 3,
                BorrowedDevices = 0
            },
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[1],
                Id = 2,
                Active = true,
                Name = "Młotek",
                NodeId = 1,
                FullPath = "MainFolder/",
                RentalId = 1,
                Price = 3,
                HasDevices = true,
                TotalDevices = 2,
                BorrowedDevices = 0                    
            }
        };
    public static DeviceTypeVm[] GetDeviceTypeVmSampleWithRentalId2 =>
        new DeviceTypeVm[2]
        {            
            new()
            {
                CreatorId = Users.Lessor_007.GetUserId(),
                CreatedAt = GetDateTimeSample[13],
                Id = 4,
                Active = true,
                Name = "Compactor",
                NodeId = 4,
                FullPath = "GeneralGroup/Medium weight equipment/Compactor",
                RentalId = 2,
                Price = 40,
                HasDevices = true,
                TotalDevices = 3,
                BorrowedDevices = 0,
            },
            new()
            {
                CreatorId = Users.Lessor_007.GetUserId(),
                CreatedAt = GetDateTimeSample[14],
                Id = 5,
                Active = true,
                Name = "DRILLING RIG",
                NodeId = 5,
                FullPath = "GeneralGroup/Medium weight equipment/DRILLING RIG",
                RentalId = 2,
                Price = 60,
                HasDevices = true,
                TotalDevices = 2,
                BorrowedDevices = 2,
            }
        };
}


