using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Application.Interfaces;

public interface IReservationService
{
    Task<int> AddReservationAsync(NewReservationVm viewModel, CancellationToken cancellationToken = default);
    ListReservationVm GetActiveReservationsVm();
    NewReservationVm GetNewReservationVm();
    Task<ListReservationVm> GetActiveReservationsVmAsync(CancellationToken token = default);
}