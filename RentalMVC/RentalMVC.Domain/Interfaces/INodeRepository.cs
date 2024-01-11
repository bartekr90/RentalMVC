using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Interfaces;

public interface INodeRepository
{
    Task<int> AddAsync(Node node, CancellationToken cancellationToken = default);
    Task UpdateAsync(Node node, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task DeactiveAsync(int id, CancellationToken cancellationToken = default);
    Task<Node> GetByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Node>> GetAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<IQueryable<Node>> GetChildesByParentAsync(int rentalId, int parentNodeId, CancellationToken cancellationToken = default);
}