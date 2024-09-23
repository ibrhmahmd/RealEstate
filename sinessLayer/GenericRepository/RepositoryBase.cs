using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.GenericRepository
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
            try
            {
                var list = await Context.Set<T>().ToListAsync();
                return list.AsQueryable();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while retrieving all records.", ex);
            }
        }


        public async Task<T> GetByIdAsync(Guid Id)
        {
            try
            {
                return await Context.Set<T>().FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the record with ID {Id}.", ex);
            }
        }


        public async Task HardDeleteAsync(Guid Id)
        {
            try
            {
                var delete = await GetByIdAsync(Id);
                if (delete != null)
                {
                    Context.Remove(delete);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Entity not found for deletion.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the record with ID {Id}.", ex);
            }
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(entity);
                if (!Validator.TryValidateObject(entity, validationContext, validationResults, true))
                {
                    throw new ValidationException("Entity validation failed: " + string.Join(", ", validationResults.Select(v => v.ErrorMessage)));
                }

                await Context.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the entity.", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving changes to the database.", ex);
            }
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            try
            {
                if (typeof(T) == typeof(Property))
                {
                    var entity = await Context.Set<Property>().FindAsync(id);
                    if (entity != null)
                    {
                        entity.IsAvailable = false;
                        await SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Property not found for soft deletion.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Soft delete is not supported for this entity type.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during soft deletion for entity with ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                Context.Set<T>().Update(entity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the entity.", ex);
            }
        }

        public async Task<IQueryable<T>> GetByNameAsync(string name)
        {
            try
            {
                /*var list = await Context.Set<T>().ToListAsync();
                return list.AsQueryable();*/
                return Context.Set<T>().Where(e => EF.Property<string>(e, "Name") == name).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity by name: {name}.", ex);
            }
        }
    }
}

