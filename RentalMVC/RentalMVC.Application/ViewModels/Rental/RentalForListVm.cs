using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.Lessor;

namespace RentalMVC.Application.ViewModels.Rental;

public class RentalForListVm : IBaseVm
{
    public required string Name { get; set; }
    public required int LessorId { get; set; }
    public virtual required LessorForListVm Lessor { get; set; }
    public int MainContactDataId { get; set; }
    public string? Address { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}
