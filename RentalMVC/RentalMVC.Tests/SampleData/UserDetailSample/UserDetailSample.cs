using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Tests.SampleData.UserDetailSample;
internal class UserDetailSample
{
    public static UserDetail NewUserDetail => new()
    {
        CreatorId = "",
    };

    public static UserDetail[] GetUserDetailsSample =>
        new UserDetail[]
        {
            new ()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                Active = true,
                CreatedAt = GetDateTimeSample[0],
                ModifiedAt = GetModifiedDateTimeSample[0],
                ModifierId = Users.Admin_001.GetUserId(),
                LessorId = 1,
                Id = 1,
                Lessor = NewLessor,
            },
            new()
            {
                CreatorId = Users.Client_003.GetUserId(),
                Active = true,
                CreatedAt = GetDateTimeSample[1],
                ClientId = 1,
                Client = NewClient,
                Id = 2,
            },
            new()
            {
                CreatorId = Users.Employee_008.GetUserId(),
                Active = true,
                CreatedAt = GetDateTimeSample[3],
                EmployeeId = 1,
                Employee = NewEmployee,
                Id = 3,
                ModifiedAt= GetDateTimeSample[4],
                ModifierId= Users.Lessor_006.GetUserId(),
            },
            new()
            {
                Id = 4,
                CreatorId = Users.Lessor_007.GetUserId(),
                Active = true,
                CreatedAt = GetDateTimeSample[10],
                ModifiedAt = GetModifiedDateTimeSample[11],
                ModifierId = Users.Admin_001.GetUserId(),
                LessorId = 2,
                Lessor = NewLessor,
            }
        };
}