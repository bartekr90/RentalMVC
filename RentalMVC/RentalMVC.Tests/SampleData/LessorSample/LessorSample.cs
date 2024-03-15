namespace RentalMVC.Tests.SampleData.LessorSample;

internal class LessorSample
{
    public static Lessor NewLessor => new()
    {
        CreatorId = "",
        Name = "",
        UserDetail = NewUserDetail,
        UserId = "",
    };
    public static Lessor[] GetLessorsSample =>
            new Lessor[]
            {
                new()
                {
                    CreatorId = Users.Admin_001.GetUserId(),
                    Name = "ImTheBoss",
                    UserDetail = NewUserDetail,
                    UserId = Users.Lessor_006.GetUserId(),
                    Id = 1,
                    Active = true,
                    CreatedAt = GetDateTimeSample[0],
                    CanLaunchRental = true,
                    UserDetailId = 1,
                    Rental = NewRental,
                    RentalId = 1,
                    MainContactData = NewContactData,
                    MainContactDataId = 1,
                },
                new()
                {
                    CreatorId = Users.Admin_001.GetUserId(),
                    Name = "ChiefOfRental",
                    UserDetail = NewUserDetail,
                    UserId = Users.Lessor_007.GetUserId(),
                    Id = 2,
                    Active = true,
                    CreatedAt = GetDateTimeSample[10],
                    CanLaunchRental = true,
                    UserDetailId = 4,
                    Rental = NewRental,
                    RentalId = 2,
                    MainContactData = NewContactData,
                    MainContactDataId = 3                                                                                
                }
            };
}
