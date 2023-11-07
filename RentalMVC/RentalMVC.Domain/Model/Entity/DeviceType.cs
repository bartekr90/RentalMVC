using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity;

public class DeviceType : BaseEntity
{
    public required string Name { get; set; }
    public required string FullPath { get; set; }
    public string? Description { get; set; }
    public int BorrowedDevices { get; set; }
    public int TotalDevices { get; set; }
    public decimal Price { get; set; }
    public bool HasDevices { get; set; }
    public int NodetId { get; set; }
    public virtual required Node Node { get; set; }
    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
    public virtual ICollection<ReservationPosition> Positions { get; set; } = new List<ReservationPosition>();
}
