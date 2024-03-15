using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.Employee;

public class EmployeeForListVm : IBaseVm
{
    public required string Name { get; set; }
    public bool DidCreateDevices { get; set; }
    public bool DidCreateTypes { get; set; }
    public bool DidCreateNodes { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}