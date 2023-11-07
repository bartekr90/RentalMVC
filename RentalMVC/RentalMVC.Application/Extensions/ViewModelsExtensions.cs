using RentalMVC.Application.ViewModels.Reservation;
using System.Text;

namespace RentalMVC.Application.Extensions;

public static class ViewModelsExtensions
{
    public static string GetReservationTitle(this NewReservationVm reservation)
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
