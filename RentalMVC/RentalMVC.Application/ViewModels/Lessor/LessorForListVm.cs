using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.Lessor;
public class LessorForListVm : IBaseVm, IBaseRentalVm
{
    public required string Name { get; set; }
    public int MainContactDataId { get; set; }
    public string? Address { get; set; }
    public bool CanLaunchRental { get; set; }
    public bool DidCreateDevices { get; set; }
    public bool DidCreateTypes { get; set; }
    public bool DidCreateNodes { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
}