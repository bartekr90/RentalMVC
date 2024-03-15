using RentalMVC.Application.ViewModels.Client;
using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Application.ViewModels.Reservation;

public class EditReservationVm : IBaseVm, IBaseRentalVm, IAuditableVm
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public required string ClientName { get; set; }
    public required string Title { get; set; }
    public bool DuringExecution { get; set; }
    public string? Comments { get; set; }
    public decimal Value { get; set; }
    public int ClientId { get; set; }
    public required ClientForListVm Client { get; set; }
    public required ListPositionExtendedVm Positions { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public int RentalId { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public required string RentalName { get; set; }   
}
