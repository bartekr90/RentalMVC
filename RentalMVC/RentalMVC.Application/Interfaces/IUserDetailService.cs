using RentalMVC.Application.Parameters.UserDetail;

namespace RentalMVC.Application.Interfaces;

public interface IUserDetailService
{
    Task<int> GetRentalIdFromDetails(UserDetailParams userDetailParams);
}
