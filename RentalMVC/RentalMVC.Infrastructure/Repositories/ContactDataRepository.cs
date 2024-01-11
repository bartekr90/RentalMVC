using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class ContactDataRepository: IContactDataRepository
{
    private readonly Context _context;

    public ContactDataRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(ContactData contact, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<ContactData>> GetAsync(string creatorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<ContactData>> GetAsync(string creatorId, int addressId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ContactData> GetByIdAsync(string creatorId, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<ContactData>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ContactData contact, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
