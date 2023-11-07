using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IReservationRepository
{
    Task<int> CreateAsync(Reservation reservation, CancellationToken cancellationToken = default);
    Task<List<Reservation>> GetActiveReservationsAsync(CancellationToken cancellationToken = default);
    IQueryable<Reservation> GetActiveReservations();
    Task<Reservation?> GetReservationAsync(int id, CancellationToken cancellationToken = default);
    Task<Reservation?> GetActiveReservationAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default);
}