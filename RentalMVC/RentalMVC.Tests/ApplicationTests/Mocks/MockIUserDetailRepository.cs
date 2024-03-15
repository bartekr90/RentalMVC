using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockIUserDetailRepository
{
    public static Mock<IUserDetailRepository> GetMock()
    {
        var mock = new Mock<IUserDetailRepository>();

        List<UserDetail> userDetails = GetUserDetailsSample.ToList();

        mock.Setup(m => m.GetByIdExtendedAsync(It.IsAny<UserId>(), It.IsAny<CancellationToken>()))
            .Returns((UserId creatorId, CancellationToken token) =>
            {
                var userDetail = userDetails
                .FirstOrDefault(ud => ud.CreatorId == creatorId.Value && ud.Deleted == false);

                if (userDetail != null)
                {
                    if(userDetail.ClientId is not null)
                    userDetail.Client = GetClientsSample[userDetail.ClientId.Value - 1];
                    if(userDetail.LessorId is not null)
                    userDetail.Lessor = GetLessorsSample[userDetail.LessorId.Value - 1];
                    if(userDetail.EmployeeId is not null)
                    userDetail.Employee = GetEmployeesSample[userDetail.EmployeeId.Value - 1];                
                }
                return Task.FromResult(userDetail);
            });

        return mock;
    }
}
