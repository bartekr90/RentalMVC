using RentalMVC.Domain.Model.Entity;
using ReservationMVC.Domain.Interfaces;

namespace RentalMVC.Infrastructure.Repositories;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(Context context)
        : base(context)
    {
    }


    //public async Task<int> CreateAsync(Reservation reservation, CancellationToken cancellationToken = default)
    //{
    //    _context.Reservations.Add(reservation);
    //    await _context.SaveChangesAsync(cancellationToken);
    //    return reservation.Id;
    //}

    //public async Task<Reservation?> GetActiveReservationAsync(int id, CancellationToken cancellationToken = default) =>
    //    await _context.Reservations
    //    .Where(r => r.Active && !r.Deleted && r.Id == id)
    //    .FirstOrDefaultAsync(cancellationToken);

    //public async Task<List<Reservation>> GetActiveReservationsAsync(CancellationToken cancellationToken = default) =>
    //    await _context.Reservations
    //    .Where(r => r.Active && !r.Deleted)
    //    .ToListAsync(cancellationToken);

    //public IQueryable<Reservation> GetActiveReservations() =>
    //    _context.Reservations
    //        .Where(r => r.Active && !r.Deleted);    

    //public async Task<Reservation?> GetReservationAsync(int id, CancellationToken cancellationToken = default) =>
    //    await _context.Reservations
    //        .Include(r => r.Positions)
    //        .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    //public async Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default)
    //{
    //    _context.Reservations.Update(reservation);
    //    await _context.SaveChangesAsync(cancellationToken);
    //}
}


