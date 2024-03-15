namespace RentalMVC.Tests.SampleData;

internal enum Users
{
    Admin_001,
    Admin_002,
    Client_003,
    Client_004,
    Client_005,
    Lessor_006,
    Lessor_007,
    Employee_008
}

internal static class UsersExtensions
{
    public static string GetUserId(this Users user) => user switch
    {
        Users.Admin_001 => nameof(Users.Admin_001),
        Users.Admin_002 => nameof(Users.Admin_002),
        Users.Client_003 => nameof(Users.Client_003),
        Users.Client_004 => nameof(Users.Client_004),
        Users.Client_005 => nameof(Users.Client_005),
        Users.Lessor_006 => nameof(Users.Lessor_006),
        Users.Lessor_007 => nameof(Users.Lessor_007),
        Users.Employee_008 => nameof(Users.Employee_008),
        _ => throw new ArgumentOutOfRangeException(nameof(user), user, null)
    };
}