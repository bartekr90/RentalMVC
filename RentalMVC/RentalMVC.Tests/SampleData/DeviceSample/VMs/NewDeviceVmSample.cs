using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;

namespace RentalMVC.Tests.SampleData.DeviceSample.VMs;

internal static class NewDeviceVmSample
{
    public static NewDeviceVm GetNewNewDeviceVm => new()
    {
        Name = "",
        DeviceTypeId = 0,
        RentalId = 0,
        SerialNr = "",
        IndividualPrice = 0,
        Description = "",
        ListOfDeviceTypeVm = new ListDeviceTypeVm(),
    };
    public static NewDeviceVm GetNewDeviceVmTest2 => new()
    {
        Name = "",
        DeviceTypeId = 0,
        RentalId = 1,
        SerialNr = "",
        IndividualPrice = 0,
        Description = "",
        ListOfDeviceTypeVm = new ListDeviceTypeVm(),
    };

    public static NewDeviceVm[] GetExpectedNewDeviceVmSample =>
        new NewDeviceVm[2]
        {
            new()
            {
                Description = "",
                ListOfDeviceTypeVm = GetListDeviceTypeVmSampleByRental[0],
                Name = "",
                SerialNr = "",
                DeviceTypeId = 0,
                IndividualPrice = 0,
                IsActive = false,
                RentalId = 2,
                UserId = "",
            },
            new()
            {
                Description = "",
                ListOfDeviceTypeVm = GetListDeviceTypeVmSampleByRental[1],
                Name = "",
                SerialNr = "",
                DeviceTypeId = 0,
                IndividualPrice = 0,
                IsActive = false,
                RentalId = 1,
                UserId = "",
            }
        };
    public static NewDeviceVm[] GetNewDeviceVmSample =>

        new NewDeviceVm[4]
        {
            new()
            {
                Description = "pełny obiekt",
                ListOfDeviceTypeVm = new ListDeviceTypeVm(),
                Name = "New Device z id 1",
                SerialNr = "dla typu młotek z id typu =2",
                DeviceTypeId = 2,
                IndividualPrice = 4,
                IsActive = true,
                RentalId = 1,
                UserId = Users.Lessor_006.GetUserId()                
            },
            new()
            {
                Name = "model uproszczony",
                DeviceTypeId = 2,
                RentalId = 1,
                SerialNr = "model przeszedł walicację",
                ListOfDeviceTypeVm = new ListDeviceTypeVm(),
                UserId = Users.Lessor_006.GetUserId(),                
            },
            new()
            {
                Description = "pełny obiekt niekatywny",
                Name = "New Device z rental id 1",
                SerialNr = "dla typu młotek z id typu =2",
                UserId = Users.Employee_008.GetUserId(),
                DeviceTypeId = 2,
                RentalId = 1,
                IndividualPrice = 4,
                ListOfDeviceTypeVm = new ListDeviceTypeVm(), 
            },
            new()
            {
                Name = "model modyfikowany",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "model przeszedł walicację",
                IndividualPrice = 6,
                Description = "dostepny i aktywny",
                ListOfDeviceTypeVm = new ListDeviceTypeVm(),                    
            }
        };
}
