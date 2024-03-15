namespace RentalMVC.Application.ViewModels.Node;

public class ListNodeVm
{
    public List<NodeForListVm> Nodes { get; set; } = new List<NodeForListVm>();
    public int Count { get; set; }
}
