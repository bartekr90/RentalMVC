using ReservationMVC.Domain.Interfaces;

namespace RentalMVC.Domain.Interfaces;

public interface IRepositoryWrapper
{
    IClientRepository ClientRepo { get; }
    IAddressRepository AddressRepo { get; }
    IContactDataRepository ContactDataRepo { get; }
    IDeviceRepository DeviceRepo { get; }
    IDeviceTypeRepository DeviceTypeRepo { get; }
    IEmployeeRepository EmployeeRepo { get; }
    ILessorRepository LessorRepo { get; }
    INodeRepository NodeRepo { get; }
    IPositionRepository PositionRepo { get; }
    IRentalRepository RentalRepo { get; }
    IReservationRepository ReservationRepo { get; }
    IUserDetailRepository UserDetailRepo { get; }
    Task<int> SaveAsync(CancellationToken token = default);
}