using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class UserDetailRepository : IUserDetailRepository
{
    private readonly Context _context;

    public UserDetailRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(UserDetail userDetail, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetail> GetAsync(string creatorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetail> GetByClientIdAsync(string creatorId, int clientId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetail> GetByEmployeeIdAsync(string creatorId, int employeeId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetail> GetByLessorIdAsync(string creatorId, int lessorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<UserDetail>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserDetail userDetail, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
