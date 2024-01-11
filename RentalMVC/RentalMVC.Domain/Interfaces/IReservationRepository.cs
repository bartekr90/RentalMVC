using RentalMVC.Domain.Model.Entity;

namespace ReservationMVC.Domain.Interfaces;

public interface IReservationRepository
{
    Task<int> AddAsync(Reservation reservation, CancellationToken cancellationToken = default);
    Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task DeactiveAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetByRentalAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetActiveAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetDuringExecutionAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<Reservation> GetByRentalByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetByClientAsync(string creatorId, CancellationToken cancellationToken = default);
    Task<Reservation> GetByClientByIdAsync(string creatorId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetActiveAsync(string creatorId, CancellationToken cancellationToken = default);
    Task<IQueryable<Reservation>> GetDuringExecutionAsync(string creatorId, CancellationToken cancellationToken = default);
}