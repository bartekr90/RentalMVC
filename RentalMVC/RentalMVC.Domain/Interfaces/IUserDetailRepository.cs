using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IUserDetailRepository
{
    //Task<IEnumerable<UserDetail>> GetAllAsync(string creatorId, CancellationToken token);
    //Task<IEnumerable<UserDetail>> GetAllWithDetailsAsync(string creatorId, CancellationToken token);
    //Task<UserDetail?> GetByIdAsync(string creatorId, CancellationToken token);
    //void CreateUserDetail(UserDetail userDetail);
    //void UpdateUserDetail(UserDetail userDetail);
    //void RemoveUserDetail(UserDetail userDetail);
    //void DeleteUserDetail(UserDetail userDetail);
    Task<UserDetail?> GetByIdExtendedAsync(UserId creatorId, CancellationToken token);
}
