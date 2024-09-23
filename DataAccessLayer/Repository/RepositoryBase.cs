using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyDbContext Context;
        public RepositoryBase(MyDbContext _Context)
        {
            Context = _Context;
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            var list = await Context.Set<T>().ToListAsync();
            return list.AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await Context.Set<T>().FindAsync(Id);
        }

        public async Task<T> GetByNameAsync(string name)
        {
             return await Context.Set<T>().FindAsync(name);
            //return await Context.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);
        }

        public async Task HardDeleteAsync(Guid Id)
        {
            var delete = await GetByIdAsync(Id);
            Context.Remove(delete);
            await Context.SaveChangesAsync(); ;
        }

        public async Task InsertAsync(T entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            if (typeof(T) == typeof(Property))
            {
                var entity = await Context.Set<Property>().FindAsync(id);
                if (entity != null)
                {
                    entity.IsAvailable = false; 
                    await SaveChangesAsync();
                }
            }
            else
            {
                throw new InvalidOperationException("Soft delete is not supported for this entity type.");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);
            await SaveChangesAsync();
        }
    }
}
