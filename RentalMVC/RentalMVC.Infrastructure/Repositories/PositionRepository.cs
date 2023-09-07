using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class PositionRepository : IPositionRepository
{
    private readonly Context _context;

    public PositionRepository(Context context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(ReservationPosition reservationPosition, CancellationToken cancellationToken = default)
    {
        _context.ReservationPositions.Add(reservationPosition);
        await _context.SaveChangesAsync(cancellationToken);
        return reservationPosition.Id;
    }

    public async Task<ReservationPosition?> GetPositionAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.ReservationPositions
            .Include(rp => rp.Device)
            .Include(rp => rp.DeviceType)
            .Include(rp => rp.Reservation)
            .FirstOrDefaultAsync(rp => rp.Id == id, cancellationToken);

    public IQueryable<ReservationPosition> GetPositionsForType(int deviceTypeId) =>
        _context.ReservationPositions.Where(p => p.DeviceTypeId == deviceTypeId);

    public IQueryable<ReservationPosition> GetPositionsForDevice(int deviceId) =>
        _context.ReservationPositions.Where(p => p.DeviceId == deviceId);

    public IQueryable<ReservationPosition> GetPositionsForReservation(int reservationId) =>
    _context.ReservationPositions.Where(p => p.ReservationId == reservationId);

    public IQueryable<ReservationPosition> GetAllReservationPositions() =>
        _context.ReservationPositions;

    public async Task UpdateAsync(ReservationPosition reservationPosition, CancellationToken cancellationToken = default)
    {
        _context.ReservationPositions.Update(reservationPosition);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<int> CreateAsync(IEnumerable<ReservationPosition> reservationPositions, CancellationToken cancellationToken = default)
    {
        _context.ReservationPositions.AddRange(reservationPositions);
        return await _context.SaveChangesAsync(cancellationToken);
    }

}
