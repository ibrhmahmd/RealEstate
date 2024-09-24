using BusinessLayer.DTOModels;
using DataAccessLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ContractRepo : IRepository<ContractDTO>
    {
        public Task<IQueryable<ContractDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ContractDTO> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ContractDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task HardDeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(ContractDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ContractDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
