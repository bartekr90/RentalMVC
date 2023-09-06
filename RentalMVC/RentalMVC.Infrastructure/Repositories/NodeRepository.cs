using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class NodeRepository : INodeRepository
{
    private readonly Context _context;

    public NodeRepository(Context context)
    {
        _context = context;
    }

    public async Task<Node> CreateAsync(Node node)
    {
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
        return node;
    }

    public async Task<Node?> GetNodeAsync(int id) =>
        await _context.Nodes.FirstOrDefaultAsync(n => n.Id == id);

    public IQueryable<Node> GetSubNodesForParent(int parentNodeId) =>
        _context.Nodes.Where(n => n.ParentNodeId == parentNodeId);

    public IQueryable<Node> GetAllNodes() =>
        _context.Nodes;

    public async Task UpdateAsync(Node node)
    {
        _context.Nodes.Update(node);
        await _context.SaveChangesAsync();
    }
}
