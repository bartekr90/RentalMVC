using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class DeviceTypeRepository : RepositoryBase<DeviceType>, IDeviceTypeRepository
{
    public DeviceTypeRepository(Context context)
        : base(context)
    {
    }

    public async Task<DeviceType?> GetByIdAsync(DeviceTypeId id, CancellationToken token) =>
        await FindByCondition(type => type.Id == id.Value && type.Deleted == false)
        .FirstOrDefaultAsync(token);

    public async Task<IEnumerable<DeviceType>> GetTypesListByRentalIdAsync(RentalId rentalId, CancellationToken token) =>
     await FindByCondition(type => type.RentalId == rentalId.Value && type.Deleted == false)
         .OrderBy(t => t.Name)
         .ToListAsync(token);

}
