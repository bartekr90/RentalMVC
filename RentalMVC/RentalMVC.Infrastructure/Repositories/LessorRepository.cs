using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class LessorRepository : ILessorRepository
{
    private readonly Context _context;

    public LessorRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Lessor lessor, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Lessor> GetAsync(string userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Lessor>> GetByCreatorAsync(string creatorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Lessor>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Lessor lessor, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
