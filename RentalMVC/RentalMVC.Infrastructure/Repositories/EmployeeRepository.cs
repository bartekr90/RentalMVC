using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly Context _context;

    public EmployeeRepository(Context context)
    {
        _context = context;
    }
      
    public Task<int> AddAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Employee>> GetAsync(int rentalId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetAsync(string userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetAsync(int rentalId, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Employee>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
