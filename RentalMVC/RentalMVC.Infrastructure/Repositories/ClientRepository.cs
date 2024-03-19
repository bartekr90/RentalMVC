using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(Context context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken token = default)
    {
        return await FindAll()
            .OrderBy(ow => ow.Name)
            .ToListAsync(token);
    }
    public async Task<Client?> GetClientByIdAsync(string id, CancellationToken token = default)
    {
        return await FindByCondition(client => client.Id.Equals(id))
            .FirstOrDefaultAsync(token);
    }
    public async Task<Client?> GetClientWithDetailsAsync(string clientId, CancellationToken token = default)
    {
        return await FindByCondition(client => client.Id.Equals(clientId))
            .Include(c => c.MainContactData)
            .Include(c => c.UserDetail)
            .Include(c => c.Contacts)
            .Include(c => c.Positions)
            .Include(c => c.Reservations)
            .FirstOrDefaultAsync(token);
    }
    public void CreateClient(Client client)
    {
        Create(client);
    }
    public void RemoveClient(Client client)
    {
        Remove(client);
    }
    public void UpdateClient(Client client)
    {
        Update(client);
    }

    public void DeleteClient(Client client)
    {
        Update(client);
    }   
}