using RentalMVC.Application.ViewModels.Device;

namespace RentalMVC.Tests.SampleData.DeviceSample.VMs;
internal static class DeviceExtendedVmSample
{
    public static DeviceExtendedVm GetNewDeviceExtendedVm =>
        new() 
        { 
            CreatorId = "",
            Name = "",
            RentalName = "",
            SerialNr = "",
            TypeName = "",            
        };

    public static DeviceExtendedVm[] GetBadDeviceExtendedVmSample =>
        new DeviceExtendedVm[]
        {
            new()
            {
                CreatorId = "",
                Name = "",
                RentalName = "",
                SerialNr = "",
                TypeName = "",
                RentalId = 1,
                Id = 1231,
            }, 
            new()
            {
                CreatorId = "",
                Name = "",
                RentalName = "",
                SerialNr = "",
                TypeName = "",
                RentalId = 1223,
                Id = 4,
            }, 
            new()
            {
                CreatorId = "",
                Name = "",
                RentalName = "",
                SerialNr = "",
                TypeName = "",
                RentalId = 2,
                Id = 4125,
            },
            new()
            {
                CreatorId = "",
                Name = "",
                RentalName = "",
                SerialNr = "",
                TypeName = "",
                RentalId = 0,
                Id = 4123,
            },
            new()
            {
                CreatorId = "",
                Name = "",
                RentalName = "",
                SerialNr = "",
                TypeName = "",
                RentalId = 1,
                Id = 0,
            },
        };

    public static DeviceExtendedVm[] GetDeviceExtendedVmSample =>
        new DeviceExtendedVm[12]
        {
            new ()
            {
               CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[0],
                Id = 1,
                Active = true,
                Name = "Wiertarka Makita Suuper Turbo",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "TO-JEST-NUMER-1234",
                IsAvailable = true,
                IndividualPrice = 11,
                Description = "Ta wiertarka jest droższa",
                RentalName = "FirstRental",
                TypeName = "Wiertarki",
                IsOnPositions = false,
                ModifierId = null,
                ModifiedAt = null
            },
            new ()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[1],
                Id = 2,
                Active = true,
                IsAvailable = true,
                Name = "Wiertarka Bosz Super",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "TO-JEST-BOSz",
                Description = "Ta wiertarka jest standardowa",
                RentalName = "FirstRental",
                TypeName = "Wiertarki",
                IsOnPositions = false,
                IndividualPrice = null,
                ModifierId = null,
                ModifiedAt = null,
            },
            new ()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[2],
                Id = 3,
                Active = false,
                IsAvailable = false,
                Name = "Wiertarka uduś",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "TO-Kijowe-JEST",
                RentalName = "FirstRental",
                TypeName = "Wiertarki",
                ModifierId= null,
                ModifiedAt = null,
                IndividualPrice = null,
                Description = null,
                IsOnPositions = false
            },
             new()
                {
                    Id = 8,
                    Name = "model modyfikowany do usunieca",
                    DeviceTypeId = 1,
                    RentalId = 1,
                    SerialNr = "model przeszedł walicację",
                    CreatorId = Users.Lessor_006.GetUserId(),
                    IsAvailable = true,
                    Active = true,
                    CreatedAt = GetDateTimeSample[3],
                    IndividualPrice = 6,
                    Description = "dostepny i aktywny",
                    ModifiedAt = GetDateTimeSample[4],
                    ModifierId = Users.Employee_008.GetUserId(),
                    RentalName = "FirstRental",
                    TypeName = "Wiertarki",
                    IsOnPositions = false,
                },
                new()
                {
                    Id = 9,
                    Name = "model pełny do usuniecia",
                    DeviceTypeId = 1,
                    RentalId = 1,
                    SerialNr = "model przeszedł walicację",
                    CreatorId = Users.Lessor_006.GetUserId(),
                    IsAvailable = false,
                    Active = false,
                    CreatedAt = GetDateTimeSample[3],
                    IndividualPrice = 6,
                    Description = "dostepny i aktywny",
                    RentalName = "FirstRental",
                    TypeName = "Wiertarki",
                    IsOnPositions = false,
                    ModifierId = null,
                    ModifiedAt = null,                    
                },
                new()
                {
                    Id = 10,
                    Name = "model uproszczony do usuniecia",
                    DeviceTypeId = 2,
                    RentalId = 1,
                    SerialNr = "model przeszedł walicację",
                    CreatorId = Users.Lessor_006.GetUserId(),
                    IsAvailable = false,
                    Active = false,
                    CreatedAt = GetDateTimeSample[3],
                    TypeName = "Młotek",
                    RentalName = "FirstRental",
                    IsOnPositions = false,
                    Description = "",
                    IndividualPrice = null,
                    ModifiedAt = null,
                    ModifierId = null
                },
                new()
                {
                    Name = "Makita DT4",
                    DeviceTypeId = 4,
                    RentalId = 2,
                    SerialNr = "44-xx-cc",
                    CreatorId = Users.Lessor_007.GetUserId(),
                    IsAvailable = true,
                    Active = true,
                    CreatedAt = GetDateTimeSample[13],
                    Id = 12,
                    RentalName = "SecondRental",
                    TypeName = "Compactor",
                },
                new()
                {
                    Name = "Bosh WZR",
                    DeviceTypeId = 4,
                    RentalId = 2,
                    SerialNr = "33hjurc",
                    CreatorId = Users.Lessor_007.GetUserId(),
                    IsAvailable = true,
                    Active = true,
                    CreatedAt = GetDateTimeSample[13],
                    IndividualPrice = 50,
                    Description = "150kg",
                    ModifiedAt = GetModifiedDateTimeSample[13],
                    ModifierId = Users.Lessor_007.GetUserId(),
                    Id = 13,
                    RentalName = "SecondRental",
                    TypeName = "Compactor", 
                },
                new()
                {
                    Id = 14,
                    Name = "SomeCompany 443dc",
                    DeviceTypeId = 4,
                    RentalId = 2,
                    SerialNr = "445ghj",
                    CreatorId = Users.Lessor_007.GetUserId(),
                    IsAvailable = true,
                    Active = true,
                    CreatedAt = GetDateTimeSample[13],
                    IndividualPrice = 30,
                    Description = "50kg",
                    RentalName = "SecondRental",
                    TypeName = "Compactor",
                },
                new()
                {
                    Id = 15,
                    Name = "Wiertnica ręczna 5kg",
                    DeviceTypeId = 5,
                    RentalId = 2,
                    SerialNr = "6634",
                    CreatorId = Users.Lessor_007.GetUserId(),
                    IsAvailable = false,
                    Active = true,
                    CreatedAt = GetDateTimeSample[14],
                    IndividualPrice = 10,
                    RentalName = "SecondRental",
                    TypeName = "DRILLING RIG",
                },
                new()
                {
                    Id = 16,
                    Name = "WIERTNICA SPALINOWA ŚWIDER DO ZIEMI",
                    DeviceTypeId = 5,
                    RentalId = 2,
                    SerialNr = "GD-520",
                    CreatorId = Users.Lessor_007.GetUserId(),
                    IsAvailable = false,
                    Active = true,
                    CreatedAt = GetDateTimeSample[14],
                    Description = "14kg, 5,2 KM",
                    RentalName = "SecondRental",
                    TypeName = "DRILLING RIG",
                },
                new()
                {
                    Id = 17,
                    Name = "Test dla Rental2 i type 5",
                    DeviceTypeId = 5,
                    RentalId = 2,
                    SerialNr = "GD-520",
                    CreatorId = Users.Lessor_007.GetUserId(),
                    IsAvailable = true,
                    Active = false,
                    CreatedAt = GetDateTimeSample[14],
                    Description = "Dane nie poprawne",
                    RentalName = "SecondRental",
                    TypeName = "DRILLING RIG",
                },
        };
}