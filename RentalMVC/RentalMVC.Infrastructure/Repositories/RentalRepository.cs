using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly Context _context;

    public RentalRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Rental rental, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeactiveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Rental> GetAsync(string creatorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Rental>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Rental rental, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
