using RentalMVC.Application.Interfaces;
using RentalMVC.Application.Parameters.UserDetail;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Application.Services;

public class UserDetailService : IUserDetailService
{
    private readonly IRepositoryWrapper _repoWrapper;

    public UserDetailService(IRepositoryWrapper repoWrapper)
    {
        _repoWrapper = repoWrapper;
    }

    public async Task<int> GetRentalIdFromDetails(UserDetailParams detailParams)
    {
        //throw new NotImplementedException();
        
        UserDetail? userDetail = await _repoWrapper.UserDetailRepo
            .GetByIdExtendedAsync(detailParams.GetUserId, detailParams.Token);
        if (userDetail is null)
            return -1;

        if (userDetail.Lessor != null && userDetail.Lessor.RentalId != null)
            return userDetail.Lessor.RentalId.Value;

        else if (userDetail.Employee != null)
            return userDetail.Employee.RentalId;
        else
            return -1;
    }
}
