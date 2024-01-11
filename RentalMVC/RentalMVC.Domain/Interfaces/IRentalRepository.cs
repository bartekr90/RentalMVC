using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IRentalRepository
{
    Task <int> AddAsync(Rental rental, CancellationToken cancellationToken = default);
    Task UpdateAsync(Rental rental, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task DeactiveAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Rental>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<Rental> GetAsync(string creatorId, CancellationToken cancellationToken = default);
}
