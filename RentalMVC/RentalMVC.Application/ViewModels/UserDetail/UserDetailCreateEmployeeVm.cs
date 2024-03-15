using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.Employee;

namespace RentalMVC.Application.ViewModels.UserDetail;

public class UserDetailCreateEmployeeVm : IBaseVm, IAuditableVm
{
    public required NewEmployeeVm NewEmployee { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
