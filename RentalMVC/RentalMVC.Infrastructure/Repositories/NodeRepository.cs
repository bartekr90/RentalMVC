using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class NodeRepository : INodeRepository
{
    private readonly Context _context;

    public NodeRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Node node, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeactiveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Node>> GetAsync(int rentalId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Node> GetByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Node>> GetChildesByParentAsync(int rentalId, int parentNodeId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Node node, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    //public async Task<Node> CreateAsync(Node node)
    //{
    //    _context.Nodes.Add(node);
    //    await _context.SaveChangesAsync();
    //    return node;
    //}

    //public async Task<Node?> GetNodeAsync(int id) =>
    //    await _context.Nodes.FirstOrDefaultAsync(n => n.Id == id);

    //public IQueryable<Node> GetSubNodesForParent(int parentNodeId) =>
    //    _context.Nodes.Where(n => n.ParentNodeId == parentNodeId);

    //public IQueryable<Node> GetAllNodes() =>
    //    _context.Nodes;

    //public async Task UpdateAsync(Node node)
    //{
    //    _context.Nodes.Update(node);
    //    await _context.SaveChangesAsync();
    //}
}
