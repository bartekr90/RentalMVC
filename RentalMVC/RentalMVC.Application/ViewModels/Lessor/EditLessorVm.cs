using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.ContactData;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Application.ViewModels.Node;

namespace RentalMVC.Application.ViewModels.Lessor;

public class EditLessorVm : IBaseVm, IAuditableVm, IBaseRentalVm
{
    public required string Name { get; set; }
    public bool CanLaunchRental { get; set; }
    public int? MainContactDataId { get; set; }
    public virtual ContactDataForListVm? MainContactData { get; set; }
    public virtual ListContactDataVm? Contacts { get; set; }
    public virtual ListDeviceExtendedVm? Devices { get; set; }
    public virtual ListDeviceTypeExtendedVm? Types { get; set; }
    public virtual ListNodeVm? Nodes { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
}
