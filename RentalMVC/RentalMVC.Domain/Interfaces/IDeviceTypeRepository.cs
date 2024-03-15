using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceTypeRepository
{
    Task<DeviceType?> GetByIdAsync(DeviceTypeId id, CancellationToken token);
    Task<IEnumerable<DeviceType>> GetTypesListByRentalIdAsync(RentalId rentalId, CancellationToken token);
    
}