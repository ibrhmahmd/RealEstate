using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        private IRepositoryBase<AddressDTO> _addresses;
        private IRepositoryBase<ContractDTO> _contracts;
        private IRepositoryBase<PaymentDTO> _payments;
        private IRepositoryBase<PropertyDTO> _properties;
        private IRepositoryBase<UserDTO> _users;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }

        public IRepositoryBase<UserDTO> UserRepository
        {
            get
            {
                return _users ??= new RepositoryBase<UserDTO>(_context); 
            }
        }

        public IRepositoryBase<PropertyDTO> PropertiesRepository
        {
            get
            {
                return _properties ??= new RepositoryBase<PropertyDTO>(_context); 
            }
        }

        public IRepositoryBase<ContractDTO> ContractsRepository
        {
            get
            {
                return _contracts ??= new RepositoryBase<ContractDTO>(_context); 
            }
        }

        public IRepositoryBase<AddressDTO> AddressesRepository
        {
            get
            {
                return _addresses ??= new RepositoryBase<AddressDTO>(_context); 
            }
        }

        public IRepositoryBase<PaymentDTO> PaymentsRepository
        {
            get
            {
                return _payments ??= new RepositoryBase<PaymentDTO>(_context); 
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); // Save changes to the context
        }

        public void Dispose()
        {
            _context.Dispose(); // Clean up resources
        }
    }
}
