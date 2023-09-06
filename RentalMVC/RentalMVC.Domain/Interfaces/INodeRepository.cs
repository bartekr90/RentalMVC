using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface INodeRepository
{
    Task<Node> CreateAsync(Node node);
    IQueryable<Node> GetAllNodes();
    Task<Node?> GetNodeAsync(int id);
    IQueryable<Node> GetSubNodesForParent(int parentNodeId);
    Task UpdateAsync(Node node);
}