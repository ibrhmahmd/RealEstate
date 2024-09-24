using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;


namespace BusinessLayer.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepositoryBase<Address> Addresses { get; }
        IRepositoryBase<Contract> Contracts { get; }
        IRepositoryBase<Payment> Payments { get; }
        IRepositoryBase<Property> Properties { get; }
        IRepositoryBase<User> Users { get; }
        void Save();
    }
}
