using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class ClientRepository: IClientRepository
{
    private readonly Context _context;

    public ClientRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Client client, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Client> GetAsync(string creatorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Client>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Client client, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
