using RentalMVC.Application.ViewModels.Device;

namespace RentalMVC.Tests.SampleData.DeviceSample.VMs;

internal static class EditDeviceVmSample
{
    public static EditDeviceVm[] GetEditDeviceVmSample =>
        new EditDeviceVm[7]
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
                DeviceTypeVm = GetNewDeviceTypeVm,
                RentalName = "SecondRental",
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
                Id = 12,
                IsOnPositions = true,                
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
                DeviceTypeVm = GetNewDeviceTypeVm,
                RentalName = "SecondRental",
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
                IsOnPositions = true
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
                DeviceTypeVm = GetNewDeviceTypeVm,
                RentalName = "SecondRental",
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
                IsOnPositions = true
            },
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[0],
                Id = 1,
                Active = false,
                Name = "Wiertarka modyfikowana",
                RentalName = "FirstRental",
                DeviceTypeId = 1,               
                RentalId = 1,
                SerialNr = "TO-JEST-1234",
                IsAvailable = true,
                IndividualPrice = 0,
                Description = "Ta wiertarka jest niekatywna i ma zredukowaną cenę",                
                DeviceTypeVm = GetNewDeviceTypeVm,
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
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
                DeviceTypeVm= GetNewDeviceTypeVm,
                RentalName = "FirstRental",
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
                IndividualPrice = 11                            
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
                DeviceTypeVm = GetNewDeviceTypeVm,
                RentalName = "FirstRental",
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
                Active = true,
                Description = "Dostaje opis i jest aktywna"
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
                DeviceTypeVm = GetNewDeviceTypeVm,
                RentalName = "FirstRental",
                PositionsVm = new Application.ViewModels.ReservationPosition.ListPositionVm(),
                Active = true,
                IsAvailable = true,
            },
        };
}
