using RentalMVC.Domain.Model.Entity.UserEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<int> AddAsync(Employee employee, CancellationToken cancellationToken = default);
    Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Employee>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<IQueryable<Employee>> GetAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<Employee> GetAsync(string userId, CancellationToken cancellationToken = default);
    Task<Employee> GetAsync(int rentalId, int id, CancellationToken cancellationToken = default);
}
