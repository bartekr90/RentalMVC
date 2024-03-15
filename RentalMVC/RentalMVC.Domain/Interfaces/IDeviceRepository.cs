using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> GetListForTypeAsync(RentalId rentalId, DeviceTypeId typeId, CancellationToken token = default);
    Task<Device?> GetByIdAsync(RentalId rentalId, DeviceId id, CancellationToken token = default);
    Task<Device?> GetByIdExtendedAsync(RentalId rentalId, DeviceId id, CancellationToken token = default);
    void CreateDevice(Device device);
    void UpdateDevice(Device device);
    void RemoveDevice(Device device);
    void DeleteDevice(Device device);
}
