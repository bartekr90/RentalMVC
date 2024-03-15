using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.Device;
public class DeviceExtendedVm : IBaseVm, IBaseRentalVm, IAuditableVm
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public required string SerialNr { get; set; }
    public decimal? IndividualPrice { get; set; }
    public int DeviceTypeId { get; set; }
    public required string TypeName { get; set; }
    public bool IsOnPositions { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public int RentalId { get; set; }
    public required string RentalName { get; set; }
    public required string CreatorId { get; set;  }
    public DateTimeOffset CreatedAt { get; set;  }
    public string? ModifierId { get; set;  }
    public DateTimeOffset? ModifiedAt { get; set;  }
   
}
