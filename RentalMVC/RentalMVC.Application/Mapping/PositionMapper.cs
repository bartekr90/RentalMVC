using RentalMVC.Application.ViewModels.ReservationPosition;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Application.Mapping;

public static class PositionMapper
{
    /// <summary>
    /// Maps a ReservationPosition object to a PositionVm object.
    /// </summary>
    /// <param name="source">The ReservationPosition object to map.</param>
    /// <returns>A PositionVm object if successful, null otherwise.</returns>
    public static PositionVm? MapReservationPositionToPositionVm(this ReservationPosition source)
    {
        return source switch
        {
            null => null,
            _ => new PositionVm
            {
                Id = source.Id,
                Active = source.Active,
                ClientId = source.ClientId,
                DeviceId = source.DeviceId,
                DeviceTypeId = source.DeviceTypeId,
                TimeUnits = source.TimeUnits,
                ReservationId = source.ReservationId,
                SequenceNumber = source.SequenceNumber,
                Value = source.Value,
                CreatorId = source.CreatorId,
                CreatedAt = source.CreatedAt,
                ModifierId = source.ModifierId,
                ModifiedAt = source.ModifiedAt,
                DeviceName = source.Device?.Name,
                DeviceTypeName = source.DeviceType?.Name,
                RentalId = source.RentalId
            }
        };
    }
}
