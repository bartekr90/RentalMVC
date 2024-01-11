using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Interfaces;

public interface ILessorRepository
{
    Task<int> AddAsync(Lessor lessor, CancellationToken cancellationToken = default);
    Task UpdateAsync(Lessor lessor, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Lessor>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<IQueryable<Lessor>> GetByCreatorAsync(string creatorId, CancellationToken cancellationToken = default);
    Task<Lessor> GetAsync(string userId, CancellationToken cancellationToken = default);   
}