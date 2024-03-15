using RentalMVC.Application.ViewModels.Client;
using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.Employee;
using RentalMVC.Application.ViewModels.Lessor;

namespace RentalMVC.Application.ViewModels.UserDetail;

public class UserDetailForListVm : IBaseVm, IAuditableVm
{
    public int? ClientId { get; set; }
    public ClientForListVm? Client { get; set; }
    public int? LessorId { get; set; }
    public LessorForListVm? Lessor { get; set; }
    public int? EmployeeId { get; set; }
    public EmployeeForListVm? Employee { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}