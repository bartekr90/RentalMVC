using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
{
    public DeviceRepository(Context context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Device>> GetListForTypeAsync(RentalId rentalId, DeviceTypeId typeId, CancellationToken token = default) =>
        await FindByCondition(device => device.RentalId == rentalId.Value && device.DeviceTypeId == typeId.Value && device.Deleted == false)
            .OrderBy(device => device.Name)
            .ToListAsync(token);

    public async Task<Device?> GetByIdAsync(RentalId rentalId, DeviceId id, CancellationToken token = default) =>
         await FindByCondition(device => device.RentalId == rentalId.Value && device.Id == id.Value && device.Deleted == false)
            .FirstOrDefaultAsync(token);

    public async Task<Device?> GetByIdExtendedAsync(RentalId rentalId, DeviceId id, CancellationToken token = default) =>
         await FindByCondition(device => device.RentalId == rentalId.Value && device.Id == id.Value && device.Deleted == false)
            .Include(device => device.Rental)
            .Include(device => device.DeviceType)
            .Include(device => device.Positions)
            .FirstOrDefaultAsync(token);

    public void CreateDevice(Device device) =>
        Create(device);

    public void UpdateDevice(Device device) =>
        Update(device);

    public void RemoveDevice(Device device) =>
        Remove(device);

    public void DeleteDevice(Device device) =>
        Update(device);

}
