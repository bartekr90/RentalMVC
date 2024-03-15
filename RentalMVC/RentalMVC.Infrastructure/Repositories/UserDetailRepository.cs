using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class UserDetailRepository : RepositoryBase<UserDetail>, IUserDetailRepository
{
    public UserDetailRepository(Context context)
        : base(context)
    {
    }

    public async Task<UserDetail?> GetByIdExtendedAsync(UserId creatorId, CancellationToken token) =>    
         await FindByCondition(ud => ud.CreatorId == creatorId.Value)
        .Include(ud => ud.Client)
        .Include(ud => ud.Lessor)
        .Include(ud => ud.Employee)
        .SingleOrDefaultAsync(token);    
}
