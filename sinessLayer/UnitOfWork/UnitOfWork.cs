using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Repositories.Interface;
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

        public IRepository<UserDTO> Users { get; }
        public IRepository<PropertyDTO> Properties { get; }
        public IRepository<ContractDTO> Contracts { get; }
        public IRepository<AddressDTO> Addresses { get; }
        public IRepository<PaymentDTO> Payments { get; }


        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }


        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
