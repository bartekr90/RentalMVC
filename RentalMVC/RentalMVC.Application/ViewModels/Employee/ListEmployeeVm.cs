namespace RentalMVC.Application.ViewModels.Employee;
public class ListEmployeeVm
{
    public List<EmployeeForListVm> Employees { get; set; } = new List<EmployeeForListVm>();
    public int Count { get; set; }
}