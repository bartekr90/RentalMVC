using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Tests.SampleData.ReservationSample.ReservationPositionVMs;

internal class PositionVmSample
{    
    public static PositionVm[] GetPositionVmByReservationId_2 =>
        new PositionVm[]
        {
             new ()
            {
              CreatorId = Users.Client_003.GetUserId(),
              Active = true,
              ClientId = 1,
              CreatedAt = GetReserwationDateTimeSample[3],
              ReservationId = 2,
              RentalId = 2,
              DeviceTypeId = 5,
              TimeUnits = 8,
              DeviceId = 15,
              Value = 80,
              SequenceNumber = 1,
              Id = 4,
            },
            new ()
            {
              CreatorId = Users.Client_003.GetUserId(),
              Active = true,
              ClientId = 1,
              CreatedAt = GetReserwationDateTimeSample[3],
              ReservationId = 2,
              RentalId = 2,
              DeviceTypeId = 5,
              TimeUnits = 8,
              DeviceId = 16,
              Value = 480,
              SequenceNumber = 2,
              Id = 5,
            }
        };
    public static PositionVm[] GetPositionVmByReservationId_1 =>
        new PositionVm[]
        {
            new ()
            {
                CreatorId = Users.Client_003.GetUserId(),
                Active = false,
                ClientId = 1,
                CreatedAt = GetReserwationDateTimeSample[0],
                ReservationId = 1,
                RentalId = 2,
                TimeUnits = 24,
                SequenceNumber = 1,
                Value = 960,
                Id = 1,
                DeviceId = 12,
                DeviceName = "Makita DT4",
                DeviceTypeId = 4,
                DeviceTypeName = "Compactor"
            },
            new ()
            {
                CreatorId = Users.Client_003.GetUserId(),
                Active = false,
                ClientId = 1,
                CreatedAt = GetReserwationDateTimeSample[0],
                ReservationId = 1,
                RentalId = 2,
                DeviceTypeId = 4,
                DeviceTypeName = "Compactor",
                TimeUnits = 24,
                DeviceId = 13,
                Value = 1200,
                SequenceNumber = 2,
                Id = 2,
                DeviceName = "Bosh WZR",
            },
            new ()
            {
                CreatorId = Users.Client_003.GetUserId(),
                Active = false,
                ClientId = 1,
                CreatedAt = GetReserwationDateTimeSample[0],
                ReservationId = 1,
                RentalId = 2,
                DeviceTypeId = 4,
                DeviceTypeName = "Compactor",
                TimeUnits = 24,
                DeviceId = 14,
                Value = 720,
                SequenceNumber = 3,
                Id = 3,
                DeviceName = "SomeCompany 443dc"
            }
        };
}
