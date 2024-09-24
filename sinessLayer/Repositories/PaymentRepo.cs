using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PaymentRepo : IRepository<PaymentDTO>
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Payment> _dbset;

        public PaymentRepo(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbset = _context.Set<Payment>();
        }





        public Task<IQueryable<PaymentDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> HardDeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> InsertAsync(PaymentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task saveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> UpdateAsync(PaymentDTO entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<PaymentDTO>.HardDeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<PaymentDTO>.InsertAsync(PaymentDTO entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<PaymentDTO>.SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<PaymentDTO>.UpdateAsync(PaymentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
