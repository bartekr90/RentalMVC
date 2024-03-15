using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Tests.SampleData.DeviceTypeSample;

internal class DeviceTypeSample
{
    public static DeviceType NewDeviceType => new()
    {
        CreatorId = "",
        FullPath = "",
        Name = "",
        Node = NewNode,
        Rental = NewRental
    };
    public static DeviceType[] GetDeviceTypesSample =>
            new DeviceType[5]
            {
                new()
                {
                    CreatorId = Users.Lessor_006.GetUserId(),
                    CreatedAt = GetDateTimeSample[0],
                    Id = 1,
                    Active = true,
                    Name = "Wiertarki",
                    Node = NewNode,
                    NodeId = 1,
                    FullPath = "MainFolder/",
                    Rental = NewRental,
                    RentalId = 1,
                    Price = 10,
                    HasDevices = true,
                    TotalDevices = 3,
                    BorrowedDevices = 0,
                },
                new()
                {
                    CreatorId = Users.Lessor_006.GetUserId(),
                    CreatedAt = GetDateTimeSample[1],
                    Id = 2,
                    Active = true,
                    Name = "Młotek",
                    Node = NewNode,
                    NodeId = 1,
                    FullPath = "MainFolder/",
                    Rental = NewRental,
                    RentalId = 1,
                    Price = 3,
                    HasDevices = true,
                    TotalDevices = 2,
                    BorrowedDevices = 0,
                },
                new()
                {
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[12],
                    Id = 3,
                    Active = false,
                    Name = "Some broke stuff",
                    Node = NewNode,
                    NodeId = 3,
                    FullPath = "GeneralGroup/Medium weight equipment",
                    Rental = NewRental,
                    RentalId = 2,
                    Price = 10,
                    HasDevices = false,
                    TotalDevices = 0,
                    BorrowedDevices = 0,
                },
                new()
                {
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[13],
                    Id = 4,
                    Active = true,
                    Name = "Compactor",
                    Node = NewNode,
                    NodeId = 4,
                    FullPath = "GeneralGroup/Medium weight equipment/Compactor",
                    Rental = NewRental,
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
                    Node = NewNode,
                    NodeId = 5,
                    FullPath = "GeneralGroup/Medium weight equipment/DRILLING RIG",
                    Rental = NewRental,
                    RentalId = 2,
                    Price = 60,
                    HasDevices = true,
                    TotalDevices = 2,
                    BorrowedDevices = 2,
                }
            };
}

