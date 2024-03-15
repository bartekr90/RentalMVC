﻿using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.DeviceService;

public class AddDeviceParams
{
    public required NewDeviceVm ViewModel { get; set; }
    public int RentalId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public RentalId GetRentalId => new(RentalId);
}
