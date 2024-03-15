using RentalMVC.Application.ViewModels.Client;
using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.ContactData;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.Employee;
using RentalMVC.Application.ViewModels.Lessor;
using RentalMVC.Application.ViewModels.Node;
using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Application.ViewModels.Rental;
public class EditRentalVm : IBaseVm, IAuditableVm
{
    public required string Name { get; set; }
    public required int LessorId { get; set; }
    public required LessorForListVm Lessor { get; set; }
    public int MainContactDataId { get; set; }
    public virtual required ContactDataForListVm MainContactData { get; set; }
    public virtual required ListContactDataVm Contacts { get; set; }
    public virtual ListEmployeeVm? Employees { get; set; }
    public virtual ListDeviceExtendedVm? Devices { get; set; }
    public virtual ListDeviceExtendedVm? Types { get; set; }
    public virtual ListNodeVm? Nodes { get; set; }
    public virtual ListReservationVm? Reservations { get; set; }
    public virtual ListClientVm? Clients { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}
