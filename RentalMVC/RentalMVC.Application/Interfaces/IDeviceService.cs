using RentalMVC.Application.Parameters.DeviceService;
using RentalMVC.Application.ViewModels.Device;

namespace RentalMVC.Application.Interfaces;

public interface IDeviceService
{
    Task<ListDeviceVm?> GetAllDevicesListAsync(DeviceListParams deviceListParams);
    Task<EditDeviceVm?> GetDeviceForEditAsync(DeviceParams deviceParams);
    Task<DeviceExtendedVm?> GetDeviceByIdAsync(DeviceParams deviceParams);
    Task<NewDeviceVm?> GetNewDeviceAsync(NewDeviceParams newDeviceParams);
    Task<DeviceVm?> AddDeviceAsync(AddDeviceParams addDeviceParams);
    Task<DeviceVm?> UpdateDeviceAsync(UpdateDeviceParams upDeviceParams);
    Task<int?> DeleteDeviceAsync(DeleteDeviceParams deleteDeviceParams);
    Task<int?> RemoveDeviceAsync(RemoveDeviceParams removeDeviceParams);
}
