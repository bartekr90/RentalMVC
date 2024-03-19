using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceTypeRepository
{
    Task<DeviceType?> GetActiveByIdAsync(DeviceTypeId id, CancellationToken token);
    Task<IEnumerable<DeviceType>> GetActiveTypesListByRentalIdAsync(RentalId rentalId, CancellationToken token);
    void UpdateDeviceType(DeviceType deviceType);
}