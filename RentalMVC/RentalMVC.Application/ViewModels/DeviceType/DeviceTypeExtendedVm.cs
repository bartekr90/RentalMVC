using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.DeviceType;

public class DeviceTypeExtendedVm : IBaseVm
{
    public required string Name { get; set; }
    public required string FullPath { get; set; }
    public int BorrowedDevices { get; set; }
    public string? Description { get; set; }
    public int TotalDevices { get; set; }
    public decimal Price { get; set; }
    public bool HasDevices { get; set; }
    public int NodeId { get; set; }
    public required string NodeName { get; set; }
    public bool BeenRented { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}
