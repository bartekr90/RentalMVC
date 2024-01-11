using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IClientRepository
{
    Task<int> AddAsync(Client client, CancellationToken cancellationToken = default);
    Task UpdateAsync(Client client, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Client>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<Client> GetAsync(string creatorId, CancellationToken cancellationToken = default);
}
