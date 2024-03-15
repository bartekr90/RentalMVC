namespace RentalMVC.Tests.SampleData.ClientSample;

internal class ClientSample
{
    public static Client NewClient => new()
    {
        CreatorId = "",
        Name = "",
        UserDetail = NewUserDetail,
    };

    public static Client[] GetClientsSample =>
        new Client[]
        {
            new()
            {
                CreatorId = Users.Client_003.GetUserId(),
                Name = "ImTheClient",
                UserDetail = NewUserDetail,
                Id = 1,
                Active = true,
                CreatedAt = GetDateTimeSample[1],
                UserDetailId = 2,
                MainContactDataId = 2
            }
        };
}