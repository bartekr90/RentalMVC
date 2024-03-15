using RentalMVC.Domain.Interfaces;
using RentalMVC.Infrastructure.Repositories;
using ReservationMVC.Domain.Interfaces;

namespace RentalMVC.Infrastructure;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly Context _context;
    public RepositoryWrapper(Context context)
    {
        _context = context;
    }

    private IClientRepository? _clientRepo;
    public IClientRepository ClientRepo
    {
        get
        {
            _clientRepo ??= new ClientRepository(_context);
            return _clientRepo;
        }
    }
    private IAddressRepository? _addressRepo;
    public IAddressRepository AddressRepo
    {
        get
        {
            _addressRepo ??= new AddressRepository(_context);
            return _addressRepo;
        }
    }
    private IContactDataRepository? _contactDataRepo;
    public IContactDataRepository ContactDataRepo
    {
        get
        {
            _contactDataRepo ??= new ContactDataRepository(_context);
            return _contactDataRepo;
        }
    }
    private IDeviceRepository? _deviceRepo;
    public IDeviceRepository DeviceRepo
    {
        get
        {
            _deviceRepo ??= new DeviceRepository(_context);
            return _deviceRepo;
        }
    }
    private IDeviceTypeRepository? _deviceTypeRepo;
    public IDeviceTypeRepository DeviceTypeRepo
    {
        get
        {
            _deviceTypeRepo ??= new DeviceTypeRepository(_context);
            return _deviceTypeRepo;
        }
    }
    private IEmployeeRepository? _employeeRepo;
    public IEmployeeRepository EmployeeRepo
    {
        get
        {
            _employeeRepo ??= new EmployeeRepository(_context);
            return _employeeRepo;
        }
    }
    private ILessorRepository? _lessorRepo;
    public ILessorRepository LessorRepo
    {
        get
        {
            _lessorRepo ??= new LessorRepository(_context);
            return _lessorRepo;
        }
    }
    private INodeRepository? _nodeRepo;
    public INodeRepository NodeRepo
    {
        get
        {
            _nodeRepo ??= new NodeRepository(_context);
            return _nodeRepo;
        }
    }
    private IPositionRepository? _positionRepo;
    public IPositionRepository PositionRepo
    {
        get
        {
            _positionRepo ??= new PositionRepository(_context);
            return _positionRepo;
        }
    }
    private IRentalRepository? _rentalRepo;
    public IRentalRepository RentalRepo
    {
        get
        {
            _rentalRepo ??= new RentalRepository(_context);
            return _rentalRepo;
        }
    }
    private IReservationRepository? _reservationRepo;
    public IReservationRepository ReservationRepo
    {
        get
        {
            _reservationRepo ??= new ReservationRepository(_context);
            return _reservationRepo;
        }
    }
    private IUserDetailRepository? _userDetailRepo;
    public IUserDetailRepository UserDetailRepo
    {
        get
        {
            _userDetailRepo ??= new UserDetailRepository(_context);
            return _userDetailRepo;
        }
    }

    public async Task<int> SaveAsync(CancellationToken token = default)
    {
        return await _context.SaveChangesAsync(token);
    }
}