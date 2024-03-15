using RentalMVC.Domain.Model.Common;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Model.Entity;

public class UserDetail : BaseEntity
{
    public int? ClientId { get; set; }
    public virtual Client? Client { get; set; }
    public int? LessorId { get; set; }
    public virtual Lessor? Lessor { get; set; }
    public int? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}