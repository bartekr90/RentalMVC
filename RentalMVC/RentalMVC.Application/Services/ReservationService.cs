using AutoMapper;
using RentalMVC.Application.Interfaces;
using RentalMVC.Application.ViewModels.Reservation;
using ReservationMVC.Domain.Interfaces;
using System.Text;

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

    public Task<int> AddReservationAsync(NewReservationVm viewModel, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ListReservationVm GetActiveReservationsVm()
    {
        throw new NotImplementedException();
    }

    public Task<ListReservationVm> GetActiveReservationsVmAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public NewReservationVm GetNewReservationVm()
    {
        throw new NotImplementedException();
    }

    //public async Task<int> AddReservationAsync(NewReservationVm viewModel, CancellationToken token = default)
    //{
    //    var reservation = _mapper.Map<Reservation>(viewModel);
    //    reservation.DuringExecution = true;
    //    return await _reservationRepo.CreateAsync(reservation, token);
    //}

    //public async Task<ListReservationVm> GetActiveReservationsVmAsync(CancellationToken token = default)
    //{
    //    //List<Reservation> dBlist = await _reservationRepo.GetActiveReservationsAsync(token);
    //    ArgumentNullException.ThrowIfNull(nameof(dBlist));
    //    var reservations = _mapper.Map<List<Reservation>, List<ReservationForListVm>>(dBlist);
    //    var count = reservations.Count();

    //    return new ListReservationVm
    //    {
    //        Reservations = reservations,
    //        Count = count
    //    };
    //}

    //public ListReservationVm GetActiveReservationsVm()
    //{
    //    List<ReservationForListVm> reservations = _reservationRepo.GetActiveReservations()
    //        .ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();

    //    ArgumentNullException.ThrowIfNull(nameof(reservations));
    //    var count = reservations.Count();

    //    return new ListReservationVm
    //    {
    //        Reservations = reservations,
    //        Count = count
    //    };
    //}

    //public NewReservationVm GetNewReservationVm()
    //{
    //    //DateTimeOffset date = DateValidation();
    //    var vm = new NewReservationVm(_dateTimeProvider.Now);
    //    vm.Title = GetReservationTitle(vm);
    //    return vm;
    //}

    //private DateTimeOffset DateValidation()
    //{
    //    var now = _dateTimeProvider.Now;

    //    if (now == DateTimeOffset.MinValue)
    //    {
    //        DateTimeOffset date = now.Date.ToDateTimeOffset();
    //        return date <= now ? date : now;
    //    }
    //    return now;
    //}
    private static string GetReservationTitle( NewReservationVm reservation)
    {
        var data = reservation.StartDate.ToString().ToCharArray();

        StringBuilder sb = new StringBuilder();
        sb.Append(new char[] { 'R', 'e', 's', '_' });
        sb.Append(data, 0, 10);
        sb.Append(data, 10, 6);

        sb.Replace('.', '/');
        sb.Replace(' ', '_');
        sb.Replace(':', '-');

        return sb.ToString();
    }
}
