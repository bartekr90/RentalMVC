using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Application.Mapping;

public static class DeviceTypeMapper
{
    /// <summary>
    /// Maps a DeviceType object to a DeviceTypeVm object.
    /// </summary>
    /// <param name="source">The DeviceType object to map.</param>
    /// <returns>A DeviceTypeVm object if successful, null otherwise.</returns>
    public static DeviceTypeVm? MapDeviceTypeToDeviceTypeVm(this DeviceType source)
    {
        return source switch
        {
            null => null,
            _ => new DeviceTypeVm
            {
                Id = source.Id,
                Name = source.Name,
                FullPath = source.FullPath,
                Active = source.Active,
                BorrowedDevices = source.BorrowedDevices,
                HasDevices = source.HasDevices,
                NodeId = source.NodeId,
                Price = source.Price,
                TotalDevices = source.TotalDevices,
                CreatorId = source.CreatorId,
                CreatedAt = source.CreatedAt,
                ModifiedAt = source.ModifiedAt,
                ModifierId = source.ModifierId,
                RentalId = source.RentalId
            }
        };
    }

}

