using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity.UserEntities;

public class UserDetail : BaseEntity
{
    public int? ClientId { get; set; }
    public virtual Client? Client { get; set; }
    public int? LessorId { get; set; }
    public virtual Lessor? Lessor { get; set; }
    public int? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}