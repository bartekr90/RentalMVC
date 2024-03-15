using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Tests.SampleData.RentalSample;

internal class RentalSample
{
    public static Rental NewRental => new()
    {
        CreatorId = "",
        Name = "",
        LessorId = 0,
        Lessor = NewLessor,
        MainContactData = NewContactData,
    };

    public static Rental[] GetRentalsSample =>
            new Rental[]
            {
                new()
                {
                    CreatorId = Users.Lessor_006.GetUserId(),
                    CreatedAt = GetDateTimeSample[0],
                    Name = "FirstRental",
                    Id = 1,
                    Active = true,
                    LessorId = 1,
                    Lessor = NewLessor,
                    MainContactData = NewContactData,
                    MainContactDataId = 1,
                },
                new()
                {
                    CreatorId = Users.Lessor_007.GetUserId(),
                    CreatedAt = GetDateTimeSample[10],
                    Name = "SecondRental",
                    Id = 2,
                    Active = true,
                    LessorId = 2,
                    Lessor = NewLessor,
                    MainContactData = NewContactData,
                    MainContactDataId = 4                    
                }
            };
}

