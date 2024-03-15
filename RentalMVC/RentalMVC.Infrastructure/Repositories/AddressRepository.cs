using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(Context context)
        : base(context)
    {
    }

} 