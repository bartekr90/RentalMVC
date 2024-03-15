using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Tests.SampleData.NodeSample;

internal class NodeSample
{
    public static Node NewNode => new()
    {
        CreatorId = "",
        Name = "",
        Rental = NewRental
    };
    public static Node[] GetNodesSample =>
           new Node[5]
           {
                new()
                {
                    CreatorId = Users.Lessor_006.GetUserId(),
                    CreatedAt = GetDateTimeSample[0],
                    Id = 1,
                    Active = true,
                    Name = "MainFolder",
                    Rental = NewRental,
                    RentalId = 1,
                    DeviceType = NewDeviceType,
                    DeviceTypeId = 1,
                },
                new()
                {
                    Id = 2,
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[12],
                    Active = true,
                    Rental = NewRental,
                    DeviceType = NewDeviceType,
                    RentalId = 2,
                    Name = "GeneralGroup",
                    HasSubNodes = true,
                    
                },
                new()
                {
                    Id = 3,
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[12],
                    Active = true,
                    DeviceType = NewDeviceType,
                    Rental = NewRental,
                    RentalId = 2,
                    Name = "Medium weight equipment",
                    DeviceTypeId = 3,
                    ParentNodeId = 2,
                    HasSubNodes = true,
                    ModifiedAt = GetModifiedDateTimeSample[13],
                    ModifierId = Users.Lessor_007.GetUserId()
                },
               new()
                {
                    Id = 4,
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[13],
                    Active = true,
                    DeviceType = NewDeviceType,
                    Rental = NewRental,
                    RentalId = 2,
                    Name = "Compactor",
                    DeviceTypeId = 4,
                    ParentNodeId = 3                         
                },
               new()
                {
                    Id = 5,
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[14],
                    Active = true,
                    DeviceType = NewDeviceType,
                    Rental = NewRental,
                    RentalId = 2,
                    Name = "DRILLING RIG",
                    DeviceTypeId = 5,
                    ParentNodeId = 3                         
                },
           };
}

