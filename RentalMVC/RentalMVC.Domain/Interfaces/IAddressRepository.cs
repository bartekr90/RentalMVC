using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IAddressRepository
{    
    Task<int> AddAsync(Address adress, CancellationToken cancellationToken = default);
    Task UpdateAsync(Address adress, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Address>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<IQueryable<Address>> GetAsync(string creatorId, CancellationToken cancellationToken = default);
    Task<Address> GetAsync(string creatorId, int id, CancellationToken cancellationToken = default);
}