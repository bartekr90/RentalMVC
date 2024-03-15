using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.DeviceType;

public class DeviceTypeVm : IBaseVm, IAuditableVm
{
    public required string Name { get; set; }
    public required string FullPath { get; set; }
    public int BorrowedDevices { get; set; }
    public int TotalDevices { get; set; }
    public decimal Price { get; set; }
    public bool HasDevices { get; set; }
    public int NodeId { get; set; }   
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get ; set ; }
    public DateTimeOffset CreatedAt { get ; set ; }
    public string? ModifierId { get ; set ; }
    public DateTimeOffset? ModifiedAt { get ; set ; }
    public int RentalId { get; set ; }
}