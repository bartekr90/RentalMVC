using RentalMVC.Application.Interfaces;
using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Application.Extensions;

public static class BaseEntityExtension
{   
    public static void DeleteSetup<T>(this T entity, string userId, IDateTimeProvider date) where T : BaseEntity
    {
        entity!.Deleted = true;
        entity!.DeletedAt = date.Now;
        entity!.DeletedBy = userId;
        entity!.Active = false;
        entity!.ModifiedAt = date.Now;
        entity!.ModifierId = userId;
    }
    public static void ActiveSetup<T>(this T entity, string userId, IDateTimeProvider date, bool set) where T : BaseEntity
    {        
        entity!.Active = set;
        entity!.ModifiedAt = date.Now;
        entity!.ModifierId = userId;
    }
    public static void ModifySetup<T>(this T entity, string userId, IDateTimeProvider date) where T : BaseEntity
    {        
        entity!.ModifiedAt = date.Now;
        entity!.ModifierId = userId;
    }

}
