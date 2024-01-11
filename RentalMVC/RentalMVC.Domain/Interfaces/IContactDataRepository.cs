using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IContactDataRepository
{
    Task<int> AddAsync(ContactData contact, CancellationToken cancellationToken = default);
    Task UpdateAsync(ContactData contact, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<ContactData>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<ContactData> GetByIdAsync(string creatorId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<ContactData>> GetAsync(string creatorId, CancellationToken cancellationToken = default);
    Task<IQueryable<ContactData>> GetAsync(string creatorId, int addressId, CancellationToken cancellationToken = default);
}
