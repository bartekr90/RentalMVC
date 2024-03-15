using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class LessorRepository : RepositoryBase<Lessor>, ILessorRepository
{
    public LessorRepository(Context context)
        : base(context)
    {
    }

}
