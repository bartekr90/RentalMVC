namespace RentalMVC.Tests.SampleData.EmployeeSample;

internal class EmployeeSample
{
    public static Employee NewEmployee => new()
    {
        CreatorId = "",
        MainContactData = NewContactData,
        Name = "",
        Rental = NewRental,
        UserDetail = NewUserDetail,
        UserId = "",
    };

    public static Employee[] GetEmployeesSample =>
        new Employee[]
        {
            new()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                Name = "Employee of lessor 6",
                Rental = NewRental,
                UserDetail = NewUserDetail,
                UserId = Users.Employee_008.GetUserId(),
                Active = true,
                Id = 1,
                CreatedAt = GetDateTimeSample[4],
                RentalId = 1,
                UserDetailId = 3,
            }
        };
}
