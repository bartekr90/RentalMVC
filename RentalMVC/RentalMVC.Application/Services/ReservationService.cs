using AutoMapper;
using AutoMapper.QueryableExtensions;
using RentalMVC.Application.Extensions;
using RentalMVC.Application.Interfaces;
using RentalMVC.Application.ViewModels.Reservation;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IReservationRepository _reservationRepo;
    private readonly IMapper _mapper;

    public ReservationService(IDateTimeProvider dateTimeProvider, IReservationRepository reservationRepo, IMapper mapper)
    {
        _dateTimeProvider = dateTimeProvider;
        _reservationRepo = reservationRepo;
        _mapper = mapper;
    }

    public async Task<int> AddReservationAsync(NewReservationVm viewModel, CancellationToken token = default)
    {
        var reservation = _mapper.Map<Reservation>(viewModel);
        reservation.DuringExecution = true;
        return await _reservationRepo.CreateAsync(reservation, token);
    }

        
    //zrobic reszte akcji
    //dodac logowanie i middlwareExcaptions
    //zrobic error handling for validate (to sie miże nie udac bo to jest dla mediatoR)
    //wysłać?
    //obmyślić w jaki sposób dodawać listę pozycji do formularze rezerwacji

    public async Task<ListReservationVm> GetActiveReservationsVmAsync(CancellationToken token = default)
    {
        List<Reservation> dBlist = await _reservationRepo.GetActiveReservationsAsync(token);
        ArgumentNullException.ThrowIfNull(nameof(dBlist));
        var reservations = _mapper.Map<List<Reservation>, List<ReservationForListVm>>(dBlist);
        var count = reservations.Count();

        return new ListReservationVm
        {
            Reservations = reservations,
            Count = count
        };
    }

    public ListReservationVm GetActiveReservationsVm()
    {
        List<ReservationForListVm> reservations = _reservationRepo.GetActiveReservations()
            .ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();

        ArgumentNullException.ThrowIfNull(nameof(reservations));
        var count = reservations.Count();

        return new ListReservationVm
        {
            Reservations = reservations,
            Count = count
        };
    }

    public NewReservationVm GetNewReservationVm()
    {
        //DateTimeOffset date = DateValidation();
        var vm = new NewReservationVm(_dateTimeProvider.Now);
        vm.Title = ViewModelsExtensions.GetReservationTitle(vm);
        return vm;
    }

    private DateTimeOffset DateValidation()
    {
        var now = _dateTimeProvider.Now;

        if (now == DateTimeOffset.MinValue)
        {
            DateTimeOffset date = now.Date.ToDateTimeOffset();
            return date <= now ? date : now;
        }
        return now;
    }
}
