using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IPositionRepository
{
    Task<int> CreateAsync(ReservationPosition reservationPosition, CancellationToken cancellationToken = default);
    IQueryable<ReservationPosition> GetAllReservationPositions();
    Task<ReservationPosition?> GetPositionAsync(int id, CancellationToken cancellationToken = default);
    IQueryable<ReservationPosition> GetPositionsForDevice(int deviceId);
    IQueryable<ReservationPosition> GetPositionsForReservation(int reservationId);
    IQueryable<ReservationPosition> GetPositionsForType(int deviceTypeId);
    Task UpdateAsync(ReservationPosition reservationPosition, CancellationToken cancellationToken = default);
}