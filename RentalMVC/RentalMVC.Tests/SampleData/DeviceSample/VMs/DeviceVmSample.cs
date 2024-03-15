using RentalMVC.Application.ViewModels.Device;

namespace RentalMVC.Tests.SampleData.DeviceSample.VMs;

internal static class DeviceVmSample
{
    public static DeviceVm[] GetDeviceVmSampleAsReturnFromEdit =>
       new DeviceVm[7]
       {
            new()
            {
                Id = 12,
                Name = "Makita DT4",
                DeviceTypeId = 4,
                RentalId = 2,
                SerialNr = "44-xx-cc",
                CreatorId = Users.Lessor_007.GetUserId(),
                IsAvailable = true,
                Active = true,
                CreatedAt = GetDateTimeSample[13],
                ModifiedAt = GetModifiedDateTimeSample[14],
                ModifierId = Users.Lessor_007.GetUserId(),

            },
            new()
            {
                Id = 13,
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
                ModifiedAt = GetModifiedDateTimeSample[15],
                ModifierId = Users.Lessor_007.GetUserId(),
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
                ModifiedAt = GetModifiedDateTimeSample[16],
                ModifierId = Users.Lessor_007.GetUserId(),
            },
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[0],
                Id = 1,
                Active = false,
                Name = "Wiertarka modyfikowana",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "TO-JEST-1234",
                IsAvailable = true,
                IndividualPrice = 0,
                Description = "Ta wiertarka jest niekatywna i ma zredukowaną cenę",
                ModifiedAt = GetModifiedDateTimeSample[17],
                ModifierId = Users.Employee_008.GetUserId(),
            },
            new ()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[1],
                Id = 2,
                Active = true,
                IsAvailable = true,
                Name = "zmieniono typ, usunieto opis, dodano cenę",
                DeviceTypeId = 2,
                RentalId = 1,
                SerialNr = "TO-JEST-BOSz",
                Description = "",
                IndividualPrice = 11,
                ModifiedAt = GetModifiedDateTimeSample[18],
                ModifierId = Users.Employee_008.GetUserId(),
            },
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[2],
                Id = 3,
                Name = "Wiertarka dobra",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "TO-Kijowe-JEST",
                Active = true,
                Description = "Dostaje opis i jest aktywna",
                ModifiedAt = GetModifiedDateTimeSample[19],
                ModifierId = Users.Employee_008.GetUserId(),
            },           
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[2],
                Id = 3,
                Name = "ten obiekt ma zmienione pole dostępności",
                DeviceTypeId = 1,
                RentalId = 1,
                SerialNr = "TO-Kijowe-JEST",
                Active = true,
                ModifiedAt = GetModifiedDateTimeSample[19],
                ModifierId = Users.Employee_008.GetUserId(),                
            
            },
       };
    public static DeviceVm[] GetDeviceVmSampleRentalId2TypeId5 =>
       new DeviceVm[3]
       {
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
                 },
       };
    public static DeviceVm[] GetDeviceVmSampleRentalId2TypeId4 =>
        new DeviceVm[3]
        {
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
                 },
        };

    public static DeviceVm[] GetDeviceVmSampleRentalId1TypeId2 =>
        new DeviceVm[4]
        {
                new()
                {
                    Description = "pełny obiekt",
                    Name = "New Device z id 1",
                    SerialNr = "dla typu młotek z id typu =2",
                    DeviceTypeId = 2,
                    IndividualPrice = 4,
                    RentalId = 1,
                    CreatorId = Users.Lessor_006.GetUserId(),
                    Active = true,
                    CreatedAt= GetDateTimeSample[3],
                    IsAvailable = true,
                    Id = 6,
                },
                new()
                {
                    Name = "model uproszczony",
                    DeviceTypeId = 2,
                    RentalId = 1,
                    SerialNr = "model przeszedł walicację",
                    CreatorId = Users.Lessor_006.GetUserId(),
                    Id = 7,
                    IsAvailable = false,
                    Active = false,
                    CreatedAt = GetDateTimeSample[3],
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

                },
                new()
                {
                    Description = "pełny obiekt niekatywny",
                    Name = "New Device z rental id 1",
                    SerialNr = "dla typu młotek z id typu =2",
                    DeviceTypeId = 2,
                    IndividualPrice = 4,
                    RentalId = 1,
                    CreatorId = Users.Employee_008.GetUserId(),
                    Active = false,
                    CreatedAt= GetDateTimeSample[3],
                    IsAvailable = false,
                    Id = 11,
                },
        };

    public static DeviceVm[] GetDeviceVmSampleRentalId1TypeId1 =>
    new DeviceVm[5]
    {
                new()
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
                },
                new()
                {
                    CreatorId = Users.Lessor_006.GetUserId(),
                    CreatedAt = GetDateTimeSample[2],
                    Id = 3,
                    Name = "Wiertarka uduś",
                    DeviceTypeId = 1,
                    RentalId = 1,
                    SerialNr = "TO-Kijowe-JEST",
                },
                new()
                {
                    Name = "model modyfikowany do usunieca",
                    DeviceTypeId = 1,
                    RentalId = 1,
                    SerialNr = "model przeszedł walicację",
                    CreatorId = Users.Lessor_006.GetUserId(),
                    Id = 8,
                    IsAvailable = true,
                    Active = true,
                    CreatedAt = GetDateTimeSample[3],
                    IndividualPrice = 6,
                    Description = "dostepny i aktywny",
                    ModifiedAt = GetDateTimeSample[4],
                    ModifierId = Users.Employee_008.GetUserId(),
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
                }
    };

    public static DeviceVm[] GetDeviceVmSample =>
    new DeviceVm[4]
    {
            new()
            {
                Description = "pełny obiekt",
                Name = "New Device z id 1",
                SerialNr = "dla typu młotek z id typu =2",
                IndividualPrice = 4,
                CreatorId = Users.Lessor_006.GetUserId(),
                Active = true,
                CreatedAt= GetDateTimeSample[3],
                IsAvailable = true,
                Id = 6,
                ModifierId = null,
                ModifiedAt = null,
                DeviceTypeId = 2,
                RentalId = 1
            },
            new()
            {
                Name = "model uproszczony",
                SerialNr = "model przeszedł walicację",
                CreatorId = Users.Lessor_006.GetUserId(),
                Id = 7,
                IsAvailable = false,
                Active = false,
                CreatedAt = GetDateTimeSample[3],
                Description = null,
                IndividualPrice = null,
                ModifiedAt = null,
                ModifierId = null,
                DeviceTypeId = 2,
                RentalId = 1

            },
            new()
            {
                Name = "model modyfikowany",
                SerialNr = "model przeszedł walicację",
                CreatorId = Users.Lessor_006.GetUserId(),
                Id = 8,
                IsAvailable = true,
                Active = true,
                CreatedAt = GetDateTimeSample[3],
                IndividualPrice = 6,
                Description = "dostepny i aktywny",
                ModifiedAt = GetDateTimeSample[4],
                ModifierId = Users.Employee_008.GetUserId(),
                DeviceTypeId = 1,
                RentalId = 1

            },
            new()
            {
                Description = "pełny obiekt niekatywny",
                Name = "New Device z rental id 1",
                SerialNr = "dla typu młotek z id typu =2",
                IndividualPrice = 4,
                Active = false,
                CreatedAt= GetDateTimeSample[3],
                IsAvailable = false,
                Id = 11,
                CreatorId = Users.Employee_008.GetUserId(),
                ModifiedAt = null,
                ModifierId = null,
                DeviceTypeId = 2,
                RentalId = 1
            },
    };
}
