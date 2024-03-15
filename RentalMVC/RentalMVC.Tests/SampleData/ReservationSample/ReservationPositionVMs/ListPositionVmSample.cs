using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Tests.SampleData.ReservationSample.ReservationPositionVMs;

internal class ListPositionVmSample
{
    public static ListPositionVm GetListPositionVmByDeviceId_12 =>
        new ListPositionVm
        {            
            Positions = new List<PositionVm>
            {
                GetPositionVmByReservationId_1[0]
            },
            Count = 1,            
        };
    
    public static ListPositionVm GetListPositionVmByDeviceId_13 =>
        new ListPositionVm
        {            
            Positions = new List<PositionVm>
            {
                GetPositionVmByReservationId_1[1]
            },
            Count = 1,            
        };

    public static ListPositionVm GetListPositionVmByDeviceId_14 =>
        new ListPositionVm
        {            
            Positions = new List<PositionVm>
            {
                GetPositionVmByReservationId_1[2]
            },
            Count = 1,            
        };

    public static ListPositionVm[] GetListPositionVmByReservationId_1 =>
        new ListPositionVm[]
        {
            new() 
            { 
                Positions = GetPositionVmByReservationId_1.ToList(),
                Count = 3,
            },
        };
}
