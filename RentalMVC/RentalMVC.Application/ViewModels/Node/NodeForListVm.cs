using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.Node;

public class NodeForListVm : IBaseVm
{
    public required string Name { get; set; }
    public bool HasSubNodes { get; set; }
    public bool HasParentNode { get; set; }
    public bool IsDeviceType { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}