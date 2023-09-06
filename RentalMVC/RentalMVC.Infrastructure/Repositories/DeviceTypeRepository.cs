using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class DeviceTypeRepository : IDeviceTypeRepository
{
    private readonly Context _context;

    public DeviceTypeRepository(Context context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(DeviceType deviceType, CancellationToken cancellationToken = default)
    {
        _context.DeviceTypes.Add(deviceType);
        await _context.SaveChangesAsync(cancellationToken);
        return deviceType.Id;
    }

    public async Task<DeviceType?> GetTypeAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.DeviceTypes
            .Include(dt => dt.Node)
            .FirstOrDefaultAsync(dt => dt.Id == id, cancellationToken);

    public IQueryable<DeviceType> GetAllDeviceTypes() =>
        _context.DeviceTypes;

    public async Task UpdateAsync(DeviceType deviceType, CancellationToken cancellationToken = default)
    {
        _context.DeviceTypes.Update(deviceType);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
