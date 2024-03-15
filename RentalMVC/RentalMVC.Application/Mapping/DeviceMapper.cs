using RentalMVC.Application.Interfaces;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Application.ViewModels.ReservationPosition;
using RentalMVC.Domain.Model.Entity;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Application.Mapping;

public static class DeviceMapper
{
    /// <summary>
    /// Maps a Device object to a DeviceExtendedVm object.
    /// </summary>
    /// <param name="source">The Device object to map.</param>
    /// <returns>A DeviceExtendedVm object if successful, null otherwise.</returns>
    public static DeviceExtendedVm? MapDeviceToDeviceExtendedVm(this Device source)
    {
        if (source is { Rental: not null, DeviceType: not null })
        {
            bool hasPositions = source.Positions?.Any() ?? false;

            return new DeviceExtendedVm
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                SerialNr = source.SerialNr,
                IndividualPrice = source.IndividualPrice,
                DeviceTypeId = source.DeviceTypeId,
                TypeName = source.DeviceType.Name,
                Active = source.Active,
                IsAvailable = source.IsAvailable,
                RentalId = source.RentalId,
                IsOnPositions = hasPositions,
                RentalName = source.Rental.Name,
                CreatorId = source.CreatorId,
                CreatedAt = source.CreatedAt,
                ModifiedAt = source.ModifiedAt,
                ModifierId = source.ModifierId
            };
        }
        return null;
    }

    /// <summary>
    /// Maps a Device object to a DeviceVm object.
    /// </summary>
    /// <param name="source">The Device object to map.</param>
    /// <returns>A DeviceVm object if successful, null otherwise.</returns>
    public static DeviceVm? MapDeviceToDeviceVm(this Device source)
    {
        return source switch
        {
            null => null,
            _ => new DeviceVm
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                SerialNr = source.SerialNr,
                IndividualPrice = source.IndividualPrice,
                Active = source.Active,
                IsAvailable = source.IsAvailable,
                CreatorId = source.CreatorId,
                CreatedAt = source.CreatedAt,
                ModifiedAt = source.ModifiedAt,
                ModifierId = source.ModifierId,
                DeviceTypeId = source.DeviceTypeId,
                RentalId = source.RentalId
            }
        };
    }

    /// <summary>
    /// Maps a Device object to an EditDeviceVm object.
    /// </summary>
    /// <param name="source">The Device object to map.</param>
    /// <param name="sourceName">The name of the source.</param>
    /// <returns>An EditDeviceViewModel object if successful, null otherwise.</returns>
    public static EditDeviceVm? MapDeviceToEditDeviceVm(this Device source, string sourceName)
    {
        if (source.Rental is null 
            || source.DeviceType is null)
            return null;

        DeviceTypeVm? sourceTypeVm = source.DeviceType.MapDeviceTypeToDeviceTypeVm();
        if (sourceTypeVm is null)
            return null;

        bool sourceIsOnPositions = source.Positions is not null && source.Positions.Any();

        ListPositionVm sourcePositionsVm = new()
        {
            Positions = new List<PositionVm>(),
            Count = 0
        };

        if (sourceIsOnPositions)
        {
            sourcePositionsVm.Positions = source.Positions!
                .Select(pos => pos.MapReservationPositionToPositionVm())
                .Where(map => map is not null)
                .Select(map =>
                {
                    map!.DeviceName = source.Name;
                    map.DeviceTypeName = sourceTypeVm.Name;
                    return map;
                })
                .ToList();

            sourcePositionsVm.Count = sourcePositionsVm.Positions.Count;
        }

        return new EditDeviceVm
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            SerialNr = source.SerialNr,
            IndividualPrice = source.IndividualPrice,
            DeviceTypeId = source.DeviceTypeId,
            Active = source.Active,
            CreatorId = source.CreatorId,
            PositionsVm = sourcePositionsVm,
            RentalName = sourceName,
            DeviceTypeVm = sourceTypeVm,
            CreatedAt = source.CreatedAt,
            IsAvailable = source.IsAvailable,
            IsOnPositions = sourceIsOnPositions,
            ModifiedAt = source.ModifiedAt,
            ModifierId = source.ModifierId,
            RentalId = source.RentalId
        };
    }

    /// <summary>
    /// Maps a NewDeviceVm object to a Device object.
    /// </summary>
    /// <param name="source">The NewDeviceVm object to map.</param>
    /// <param name="type">The DeviceType object.</param>
    /// <param name="rental">The Rental object.</param>
    /// <param name="_dateTimeProvider">The IDateTimeProvider object.</param>
    /// <returns>A Device object if successful, null otherwise.</returns>
    public static Device? MapNewDeviceVmToDevice(this NewDeviceVm source, 
        DeviceType type, 
        Rental rental, 
        IDateTimeProvider _dateTimeProvider)
    {
        if (!string.IsNullOrWhiteSpace(source.UserId) 
            && !string.IsNullOrWhiteSpace(source.Name) 
            && type is not null && rental is not null 
            && _dateTimeProvider is not null)
        {
            return new Device
            {
                Name = source.Name,
                Description = source.Description,
                SerialNr = source.SerialNr,
                IndividualPrice = source.IndividualPrice,
                DeviceTypeId = source.DeviceTypeId,
                CreatorId = source.UserId,
                DeviceType = type,
                Rental = rental,
                Active = source.IsActive,
                CreatedAt = _dateTimeProvider.Now,
                IsAvailable = source.IsActive,
                RentalId = source.RentalId
            };
        }
        return null;
    }

    /// <summary>
    /// Maps properties from an EditDeviceVm to a Device.
    /// </summary>
    /// <param name="source">The source EditDeviceVm.</param>
    /// <param name="target">The target Device.</param>
    /// <returns>The target Device with properties mapped from the source EditDeviceVm.</returns>
    public static Device? MapEditDeviceVmToDevice(this EditDeviceVm source, Device target)
    {
        switch (source, target)
        {
            case (null, _):
            case (_, null):
                return target;
            default:
                target.Name = source.Name;
                target.Description = source.Description;
                target.SerialNr = source.SerialNr;
                target.IndividualPrice = source.IndividualPrice;
                target.DeviceTypeId = source.DeviceTypeId;
                target.Active = source.Active;
                return target;
        }
    }

    /// <summary>
    /// Maps a ListDeviceTypeVm object to a NewDeviceVm object.
    /// </summary>
    /// <param name="types">The ListDeviceTypeVm object to map.</param>
    /// <param name="rentalId">The ID of the rental.</param>
    /// <returns>A NewDeviceVm object if successful, null otherwise.</returns>
    public static NewDeviceVm? MapListDeviceTypeForNewDeviceVm(this ListDeviceTypeVm types, int rentalId)
    {
        return types switch
        {
            null => null,
            _ => new NewDeviceVm
            {
                Name = "",
                SerialNr = "",
                Description = "",
                IndividualPrice = 0,
                ListOfDeviceTypeVm = types,
                RentalId = rentalId,
                IsActive = false,
                DeviceTypeId = 0,
                UserId = ""
            }
        };
    }

}
