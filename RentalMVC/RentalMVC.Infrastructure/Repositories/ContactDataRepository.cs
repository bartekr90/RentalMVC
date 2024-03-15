using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class ContactDataRepository : RepositoryBase<ContactData>, IContactDataRepository
{
    public ContactDataRepository(Context context)
        : base(context)
    {
    }

}
