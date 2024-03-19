using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Application.Extensions;

public static class DeviceTypeExtensions
{
    public static void IncreaseTotalNumber(this DeviceType type)
    {
        type.TotalDevices++;
    }
    
    public static void DecreaseTotalNumber(this DeviceType type)
    {
        if (type.TotalDevices <= 0)
            throw new ArgumentException($"Invalid TotalDevices of type with id: {type.Id}");
        type.TotalDevices--;
    }
}
