using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
{
    public RentalRepository(Context context)
        : base(context)
    {
    }

    public async Task<Rental?> GetByIdAsync(RentalId id, CancellationToken token) =>    
       await FindByCondition(r => r.Id == id.Value && r.Deleted == false)
            .FirstOrDefaultAsync(token);    

    public async Task<string?> GetNameByIdAsync(RentalId rentalId, CancellationToken token)
    {
        Rental? rental =  await FindByCondition(r => r.Id == rentalId.Value  && r.Deleted == false)
            .FirstOrDefaultAsync(token);
        return rental?.Name;
    }   
}
