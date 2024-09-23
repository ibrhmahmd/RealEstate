using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetByNameAsync(string name);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(Guid id);
        Task HardDeleteAsync(Guid Id);
        Task SaveChangesAsync();
    }
}
