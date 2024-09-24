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

        // Repositories for entity types
        private IRepositoryBase<Address> _addresses;
        private IRepositoryBase<Contract> _contracts;
        private IRepositoryBase<Payment> _payments;
        private IRepositoryBase<Property> _properties;
        private IRepositoryBase<User> _users;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }

        // Repositories for DTO types
        public IRepositoryBase<User> UserRepository
        {
            get
            {
                return _users ??= new RepositoryBase<User>(_context); // Lazy initialization
            }
        }

        public IRepositoryBase<Property> PropertiesRepository
        {
            get
            {
                return _properties ??= new RepositoryBase<Property>(_context); // Lazy initialization
            }
        }

        public IRepositoryBase<Contract> ContractsRepository
        {
            get
            {
                return _contracts ??= new RepositoryBase<Contract>(_context); // Lazy initialization
            }
        }

        public IRepositoryBase<Address> AddressesRepository
        {
            get
            {
                return _addresses ??= new RepositoryBase<Address>(_context); // Lazy initialization
            }
        }

        public IRepositoryBase<Payment> PaymentsRepository
        {
            get
            {
                return _payments ??= new RepositoryBase<Payment>(_context); // Lazy initialization
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
