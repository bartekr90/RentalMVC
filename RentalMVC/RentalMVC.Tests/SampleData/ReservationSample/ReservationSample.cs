using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Tests.SampleData.ReservationSample;

internal class ReservationSample
{
    public static Reservation NewReservation => new()
    {
        CreatorId = "",
        Client = NewClient,
        ClientName = "",
        Positions = new List<ReservationPosition>(),
        Rental = NewRental,
        RentalName = "",
        Title = "",
    };
    public static Reservation[] GetReservationsSample =>
            new Reservation[] 
            {
                new()
                {
                    Client = NewClient,
                    ClientName = "ImTheClient",
                    CreatorId = Users.Client_003.GetUserId(),
                    Positions = new List<ReservationPosition>(),
                    Rental = NewRental,
                    RentalName = "SecondRental",
                    Title = "SomeTitle",
                    Active = false,
                    ClientId = 1,
                    Comments = "Stuff is returned because of activ and owned by customer is false",
                    RentalId = 2,
                    Id = 1,
                    CreatedAt = GetReserwationDateTimeSample[0],
                    StartDate = GetReserwationDateTimeSample[1],
                    EndDate = GetReserwationDateTimeSample[2],
                    IsOwnedByCustomer = false,
                    Value = 2880
                },
                new()
                {
                    Client = NewClient,
                    ClientName = "ImTheClient",
                    CreatorId = Users.Client_003.GetUserId(),
                    Positions = new List<ReservationPosition>(),
                    Rental = NewRental,
                    RentalName = "SecondRental",
                    Title = "SomeTitle2",
                    Active = true,
                    ClientId = 1,
                    Comments = "Stuff is rented because of activ is true",
                    RentalId = 2,
                    Id = 2,
                    CreatedAt = GetReserwationDateTimeSample[3],
                    StartDate = GetReserwationDateTimeSample[4],
                    EndDate = GetReserwationDateTimeSample[5],
                    IsOwnedByCustomer = true,
                    Value = 560
                }
            };
    public static ReservationPosition NewPosition => new()
    {
        CreatorId = "",
        Client = NewClient,
        Device = NewDevice,
        DeviceType = NewDeviceType,
        Rental = NewRental,
        Reservation = NewReservation,
    };
    public static ReservationPosition[] GetPositionsSample =>
        new ReservationPosition[]
        {
            new ()
            {
              Client = NewClient,
              CreatorId = Users.Client_003.GetUserId(),
              Device = NewDevice,
              DeviceType = NewDeviceType,
              Rental = NewRental,
              Reservation = NewReservation,
              Active = false,
              ClientId = 1,
              CreatedAt = GetReserwationDateTimeSample[0],
              ReservationId = 1,
              RentalId = 2,
              DeviceId = 12,
              DeviceTypeId = 4,
              TimeUnits = 24,
              SequenceNumber = 1,
              Value = 960,
              Id = 1,
            },
            new ()
            {
              Client = NewClient,
              CreatorId = Users.Client_003.GetUserId(),
              Device = NewDevice,
              DeviceType = NewDeviceType,
              Rental = NewRental,
              Reservation = NewReservation,
              Active = false,
              ClientId = 1,
              CreatedAt = GetReserwationDateTimeSample[0],
              ReservationId = 1,
              RentalId = 2,
              DeviceTypeId = 4,
              TimeUnits = 24,
              DeviceId = 13,
              Value = 1200,
              SequenceNumber = 2,
              Id = 2,
            },
            new ()
            {
              Client = NewClient,
              CreatorId = Users.Client_003.GetUserId(),
              Device = NewDevice,
              DeviceType = NewDeviceType,
              Rental = NewRental,
              Reservation = NewReservation,
              Active = false,
              ClientId = 1,
              CreatedAt = GetReserwationDateTimeSample[0],
              ReservationId = 1,
              RentalId = 2,
              DeviceTypeId = 4,
              TimeUnits = 24,
              DeviceId = 14,
              Value = 720,
              SequenceNumber = 3,
              Id = 3,
            },
            new ()
            {
              Client = NewClient,
              CreatorId = Users.Client_003.GetUserId(),
              Device = NewDevice,
              DeviceType = NewDeviceType,
              Rental = NewRental,
              Reservation = NewReservation,
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
              Client = NewClient,
              CreatorId = Users.Client_003.GetUserId(),
              Device = NewDevice,
              DeviceType = NewDeviceType,
              Rental = NewRental,
              Reservation = NewReservation,
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
}

