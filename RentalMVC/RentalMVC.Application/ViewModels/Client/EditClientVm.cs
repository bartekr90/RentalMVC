using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.ContactData;
using RentalMVC.Application.ViewModels.Reservation;
using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Application.ViewModels.Client;

public class EditClientVm : IBaseVm, IAuditableVm
{
    public required string Name { get; set; }
    public int MainContactDataId { get; set; }
    public virtual ContactDataForListVm? MainContactData { get; set; }
    public virtual ListContactDataVm? Contacts { get; set; }
    public virtual ListPositionExtendedVm? Positions { get; set; }
    public virtual ListReservationVm? Reservations { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
