using DataAccessLayer.Entities;
using System.Xml;

namespace DataAccessLayer.GenericRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(int pageNumber , int pageSize );
        Task<IQueryable<T>> GetAllIncludingDeletedAsync();

        Task<T> GetByIdAsync(Guid Id);
        Task<IQueryable<T>> GetByNameAsync(string name);
        Task<IQueryable<T>> GetAllIncludingDeletedAsync(Guid Id);

        Task<T> GetByUniqueAsync(string uniqueString, string propertyName);

        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(Guid id);
        Task RestoreSoftDeletedAsync(Guid id);
        Task HardDeleteAsync(Guid Id);
        Task<bool> Terminate(Guid Id);
        Task SaveChangesAsync();
    }
}