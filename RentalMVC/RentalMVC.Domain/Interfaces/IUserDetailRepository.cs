using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IUserDetailRepository
{
    Task<int> AddAsync(UserDetail userDetail, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserDetail userDetail, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<UserDetail>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<UserDetail> GetAsync(string creatorId, CancellationToken cancellationToken = default);
    Task<UserDetail> GetByClientIdAsync(string creatorId, int clientId, CancellationToken cancellationToken = default);
    Task<UserDetail> GetByLessorIdAsync(string creatorId, int lessorId, CancellationToken cancellationToken = default);
    Task<UserDetail> GetByEmployeeIdAsync(string creatorId, int employeeId, CancellationToken cancellationToken = default);
}
