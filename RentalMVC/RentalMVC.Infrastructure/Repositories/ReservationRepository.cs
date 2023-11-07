using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly Context _context;

    public ReservationRepository(Context context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Reservation reservation, CancellationToken cancellationToken = default)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);
        return reservation.Id;
    }

    public async Task<Reservation?> GetActiveReservationAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Reservations
        .Where(r => r.Active && !r.Deleted && r.Id == id)
        .FirstOrDefaultAsync(cancellationToken);

    public async Task<List<Reservation>> GetActiveReservationsAsync(CancellationToken cancellationToken = default) =>
        await _context.Reservations
        .Where(r => r.Active && !r.Deleted)
        .ToListAsync(cancellationToken);

    public IQueryable<Reservation> GetActiveReservations() =>
        _context.Reservations
            .Where(r => r.Active && !r.Deleted);    

    public async Task<Reservation?> GetReservationAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Reservations
            .Include(r => r.Positions)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task UpdateAsync(Reservation reservation, CancellationToken cancellationToken = default)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync(cancellationToken);
    }
}


