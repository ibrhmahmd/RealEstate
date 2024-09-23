namespace BusinessLayer.GenericRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<IQueryable<T>> GetByNameAsync(string name);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(Guid id);
        Task HardDeleteAsync(Guid Id);
        Task SaveChangesAsync();
    }
}