using RentalMVC.Application.Extensions;
using RentalMVC.Application.Interfaces;
using RentalMVC.Application.Mapping;
using RentalMVC.Application.Parameters.DeviceService;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Application.Services;

public class DeviceService : IDeviceService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IRepositoryWrapper _repoWrapper;

    public DeviceService(IRepositoryWrapper repoWrapper, IDateTimeProvider dateTimeProvider)
    {
        _repoWrapper = repoWrapper;
        _dateTimeProvider = dateTimeProvider;
    }

    /// <summary>
    /// Adds a device asynchronously.
    /// </summary>
    /// <param name="addDeviceParams">The parameters for adding the device.</param>
    /// <returns>A DeviceVm object if successful, null otherwise.</returns>
    public async Task<DeviceVm?> AddDeviceAsync(AddDeviceParams addDeviceParams)
    {
        if (addDeviceParams?.ViewModel is null 
            || addDeviceParams.RentalId <= 0)
            return null;

        Rental? rental = await _repoWrapper.RentalRepo
            .GetByIdAsync(new RentalId(addDeviceParams.ViewModel.RentalId), addDeviceParams.Token);

        DeviceType? deviceType = await _repoWrapper.DeviceTypeRepo
            .GetByIdAsync(new DeviceTypeId(addDeviceParams.ViewModel.DeviceTypeId), addDeviceParams.Token);

        if (rental is null 
            || deviceType is null 
            || rental.Id != deviceType.RentalId 
            || addDeviceParams.RentalId != rental.Id)
            return null;

        Device? device = addDeviceParams.ViewModel.MapNewDeviceVmToDevice(deviceType, rental, _dateTimeProvider);

        if (device is null)
            return null;

        _repoWrapper.DeviceRepo.CreateDevice(device);
        int changes = await _repoWrapper.SaveAsync(addDeviceParams.Token);

        return changes > 0 ? device.MapDeviceToDeviceVm() : null;
    }

    /// <summary>
    /// Deletes a device asynchronously.
    /// </summary>
    /// <param name="args">The parameters for deleting the device.</param>
    /// <returns>The number of changes if successful, null otherwise.</returns>
    public async Task<int?> DeleteDeviceAsync(DeleteDeviceParams args)
    {
        if (args?.ViewModel is null || string.IsNullOrWhiteSpace(args.UserId) || args.RentalId != args.ViewModel.RentalId)
            return null;

        Device? device = await _repoWrapper.DeviceRepo
            .GetByIdAsync(new RentalId(args.ViewModel.RentalId), new DeviceId(args.ViewModel.Id), args.Token);

        if (device is null || _dateTimeProvider is null)
            return null;

        device.DeleteSetup(args.UserId, _dateTimeProvider);
        device.IsAvailable = false;

        _repoWrapper.DeviceRepo.DeleteDevice(device);
        int changes = await _repoWrapper.SaveAsync(args.Token);

        return changes > 0 ? changes : null;
    }

    /// <summary>
    /// Gets a device by its ID asynchronously.
    /// </summary>
    /// <param name="deviceParams">The parameters for the device.</param>
    /// <returns>A DeviceExtendedVm object if successful, null otherwise.</returns>
    public async Task<DeviceExtendedVm?> GetDeviceByIdAsync(DeviceParams deviceParams)
    {
        if (deviceParams is null)
            return null;

        Device? device = await _repoWrapper.DeviceRepo
            .GetByIdExtendedAsync(deviceParams.GetRentalId, deviceParams.GetDeviceId, deviceParams.Token);

        return device?.MapDeviceToDeviceExtendedVm();
    }

    /// <summary>
    /// Gets all devices list asynchronously.
    /// </summary>
    /// <param name="deviceListParams">The parameters for the device list.</param>
    /// <returns>A ListDeviceVm object if successful, null otherwise.</returns>
    public async Task<ListDeviceVm?> GetAllDevicesListAsync(DeviceListParams deviceListParams)
    {
        var devices = await _repoWrapper.DeviceRepo
            .GetListForTypeAsync(deviceListParams.GetRentalId, deviceListParams.GetTypeId, deviceListParams.Token);

        if (devices is { } && devices.Any())
        {
            List<DeviceVm> deviceVms = devices
                .Select(device => device.MapDeviceToDeviceVm())
                .Where(deviceVm => deviceVm is not null)
                .Cast<DeviceVm>()
                .ToList();

            return new ListDeviceVm
            {
                Devices = deviceVms,
                Count = deviceVms.Count
            };
        }

        return null;
    }

    /// <summary>
    /// Fetches a device for editing purposes.
    /// </summary>
    /// <param name="deviceParams">The parameters for the device.</param>
    /// <returns>An EditDeviceViewModel object if successful, null otherwise.</returns>
    public async Task<EditDeviceVm?> GetDeviceForEditAsync(DeviceParams deviceParams)
    {
        if (deviceParams is null)
            return null;

        Device? device = await _repoWrapper.DeviceRepo
            .GetByIdExtendedAsync(deviceParams.GetRentalId, deviceParams.GetDeviceId, deviceParams.Token);

        if (device is null || device.DeviceType is null || !device.IsAvailable)
            return null;

        string? rentalName = await _repoWrapper.RentalRepo
            .GetNameByIdAsync(deviceParams.GetRentalId, deviceParams.Token);

        if (string.IsNullOrWhiteSpace(rentalName))
            return null;

        EditDeviceVm? editVm = device.MapDeviceToEditDeviceVm(rentalName);

        if (editVm is null)
            return null;

        ListDeviceTypeVm? types = await DownloadTypesListVm(deviceParams.GetRentalId, deviceParams.Token);

        if (types is null)
            return null;

        editVm.TypesListVm = types;

        return editVm;
    }

    /// <summary>
    /// Downloads a list of device types.
    /// </summary>
    /// <param name="rentalId">The ID of the rental.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A ListDeviceTypeVm object if successful, null otherwise.</returns>
    private async Task<ListDeviceTypeVm?> DownloadTypesListVm(RentalId rentalId, CancellationToken token)
    {
        var retrievedTypes = await _repoWrapper.DeviceTypeRepo
            .GetTypesListByRentalIdAsync(rentalId, token);

        if (retrievedTypes is null || !retrievedTypes.Any())
            return null;

        List<DeviceTypeVm> mappedTypes = retrievedTypes
            .Select(type => type.MapDeviceTypeToDeviceTypeVm())
            .Where(map => map is not null)
            .Cast<DeviceTypeVm>()
            .ToList();

        return new ListDeviceTypeVm
        {
            Types = mappedTypes,
            Count = mappedTypes.Count
        };
    }

    /// <summary>
    /// Gets a new device asynchronously.
    /// </summary>
    /// <param name="newDeviceParams">The parameters for the new device.</param>
    /// <returns>A NewDeviceVm object if successful, null otherwise.</returns>
    public async Task<NewDeviceVm?> GetNewDeviceAsync(NewDeviceParams newDeviceParams)
    {
        if (newDeviceParams is null)
            return null;

        var types = await DownloadTypesListVm(newDeviceParams.GetRentalId, newDeviceParams.Token);

        return types is { }
            ? types.MapListDeviceTypeForNewDeviceVm(newDeviceParams.RentalId)
            : null;
    }

    /// <summary>
    /// Updates a device asynchronously.
    /// </summary>
    /// <param name="upDeviceParams">The parameters for updating the device.</param>
    /// <returns>A DeviceVm if the update is successful, null otherwise.</returns>
    public async Task<DeviceVm?> UpdateDeviceAsync(UpdateDeviceParams upDeviceParams)
    {
        if (upDeviceParams?.ViewModel is null
            || upDeviceParams.RentalId != upDeviceParams.ViewModel.RentalId
            || string.IsNullOrWhiteSpace(upDeviceParams.UserId))
            return null;

        Device? device = await _repoWrapper.DeviceRepo
            .GetByIdAsync(upDeviceParams.GetRentalId, new DeviceId(upDeviceParams.ViewModel.Id), upDeviceParams.Token);

        if (device is not { })
            return null;

        device.ModifySetup(upDeviceParams.UserId, _dateTimeProvider);

        var deviceToSave = upDeviceParams.ViewModel.MapEditDeviceVmToDevice(device);

        if (deviceToSave is null) 
            return null;

        _repoWrapper.DeviceRepo.UpdateDevice(deviceToSave);

        int changes = await _repoWrapper.SaveAsync(upDeviceParams.Token);

        return changes > 0 ? device.MapDeviceToDeviceVm() : null;       
    }

    /// <summary>
    /// Asynchronously removes a device.
    /// </summary>
    /// <param name="entryParams">The parameters for removing the device.</param>
    /// <returns>The number of changes if the device is successfully removed; otherwise, null.</returns>
    public async Task<int?> RemoveDeviceAsync(RemoveDeviceParams entryParams)
    {
        if (entryParams?.ViewModel is null
            || entryParams.RentalId != entryParams.ViewModel.RentalId)
            return null;

        Device? device = await _repoWrapper.DeviceRepo
            .GetByIdExtendedAsync(entryParams.GetRentalId, new DeviceId(entryParams.ViewModel.Id), entryParams.Token);

        if (device is null
            || device.Positions?.Any() is true)
            return null;

        _repoWrapper.DeviceRepo.RemoveDevice(device);
        int changes = await _repoWrapper.SaveAsync(entryParams.Token);

        return changes > 0 ? changes : null;
    }
}