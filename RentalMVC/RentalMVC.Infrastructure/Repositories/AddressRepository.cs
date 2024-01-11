using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class AddressRepository:  IAddressRepository
{
    private readonly Context _context;

    public AddressRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Address adress, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Address>> GetAsync(string creatorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Address> GetAsync(string creatorId, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Address>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Address adress, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
