using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        private IRepositoryBase<Address> _addresses;
        private IRepositoryBase<Contract> _contracts;
        private IRepositoryBase<Payment> _payments;
        private IRepositoryBase<Property> _properties;
        private IRepositoryBase<User> _users;
        private IRepositoryBase<DeveloperCompany> _developerCompanies;
        private IRepositoryBase<Project> _projrcts;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }



        public IRepositoryBase<DeveloperCompany> DeveloperCompaniesRepository
        {
            get
            {
                return _developerCompanies ??= new RepositoryBase<DeveloperCompany>(_context);
            }
        }

        public IRepositoryBase<Project> ProjectsRepository
        {
            get
            {
                return _projrcts ??= new RepositoryBase<Project>(_context);
            }
        }


        public IRepositoryBase<User> UserRepository
        {
            get
            {
                return _users ??= new RepositoryBase<User>(_context);
            }
        }

        public IRepositoryBase<Property> PropertiesRepository
        {
            get
            {
                return _properties ??= new RepositoryBase<Property>(_context);
            }
        }

        public IRepositoryBase<Contract> ContractsRepository
        {
            get
            {
                return _contracts ??= new RepositoryBase<Contract>(_context);
            }
        }

        public IRepositoryBase<Address> AddressesRepository
        {
            get
            {
                return _addresses ??= new RepositoryBase<Address>(_context);
            }
        }

        public IRepositoryBase<Payment> PaymentsRepository
        {
            get
            {
                return _payments ??= new RepositoryBase<Payment>(_context);
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