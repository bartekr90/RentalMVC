using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IPositionRepository
{
    Task<int> AddAsync(ReservationPosition reservationPosition, CancellationToken cancellationToken = default);
    Task<int> AddListAsync(IQueryable<ReservationPosition> reservationPositions, CancellationToken cancellationToken = default);
    Task UpdateAsync(ReservationPosition reservationPosition, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<ReservationPosition>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<IQueryable<ReservationPosition>> GetByRentalAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<ReservationPosition> GetByRentalByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<ReservationPosition>> GetByClientAsync(int clientId, CancellationToken cancellationToken = default);
    Task<ReservationPosition> GetByClientByIdAsync(int clientId, int id, CancellationToken cancellationToken = default);
}