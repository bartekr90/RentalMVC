namespace RentalMVC.Application.ViewModels.Node;

public class NewNodeVm 
{
    public  string? Name { get; set; }
    public int? ParentNodeId { get; set; }
    public virtual NodeVm? ParentNode { get; set; }
    public bool Active { get; set; }
}
