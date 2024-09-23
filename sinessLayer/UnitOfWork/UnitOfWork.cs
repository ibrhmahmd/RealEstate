using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        public IRepositoryBase<Address> _Addresses;
        public IRepositoryBase<Contract> _Contracts;
        public IRepositoryBase<Payment> _Payments;
        public IRepositoryBase<Property> _Properties;
        public IRepositoryBase<User> _Users;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }


        public IRepositoryBase<Contract> Contracts => _Contracts ??= new RepositoryBase<Contract>(_context);

        public IRepositoryBase<Payment> Payments => _Payments ??= new RepositoryBase<Payment>(_context);

        public IRepositoryBase<Property> Properties => _Properties ??= new RepositoryBase<Property>(_context);

        public IRepositoryBase<User> Users => _Users ??= new RepositoryBase<User>(_context);

        public IRepositoryBase<Address> Addresses => _Addresses ??= new RepositoryBase<Address>(_context);

        public void Dispose()
        {
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.Dispose();
        }
    }
}
