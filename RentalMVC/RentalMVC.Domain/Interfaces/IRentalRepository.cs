using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IRentalRepository
{
    Task<Rental?> GetByIdAsync (RentalId id, CancellationToken token);
    Task<string?> GetNameByIdAsync(RentalId rentalId, CancellationToken token);

    //Task<IEnumerable<Rental>> GetDeletedAsync(CancellationToken token);
    //Task<IEnumerable<Rental>> GetListAsync(CancellationToken token);
    //Task<IEnumerable<Rental>> GetListWithDetailsAsync(CancellationToken token);
    //Task<Rental?> GetByIdAsync(int id, CancellationToken token);
    //Task<Rental?> GetByIdWithDetailsAsync(int id, CancellationToken token);
    //Task<Rental?> GetByCreatorIdAsync(string creatorId, CancellationToken token);
    //Task<Rental?> GetByCreatorIdWithDetailsAsync(string creatorId, CancellationToken token);
    //void CreateRental(Rental rental);
    //void UpdateRental(Rental rental);
    //void RemoveRental(Rental rental);
    //void DeleteRental(Rental rental);
}
