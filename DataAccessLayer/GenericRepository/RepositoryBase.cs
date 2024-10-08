using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericRepository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly MyDbContext Context;

        public RepositoryBase(MyDbContext context)
        {
            Context = context;
        }


        // Get all Items in Paged list

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().CountAsync(predicate);
        }



        public async Task<IQueryable<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                return Context.Set<T>()
                              .Where(e => EF.Property<bool>(e, "IsDeleted") == false);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving paged records.", ex);
            }
        }



        // Get all Items in Paged list
        public async Task<PagedResult<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = Context.Set<T>().AsNoTracking()
                                    .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                                    .OrderBy(e => EF.Property<int>(e, "Id")); // Ensure ordering to avoid paging inconsistencies

                return await query.ToPagedResultAsync(pageNumber, pageSize);
            }
            catch (Exception ex)

            {
                throw new Exception("An error occurred while retrieving paged records.", ex);
            }
        }



        // Get entities by name
        public async Task<IQueryable<T>> GetByNameAsync(string name)
        {
            try
            {
                return Context.Set<T>().Where(e => EF.Property<string>(e, "Name") == name && EF.Property<bool>(e, "IsDeleted") == false);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity by name: {name}.", ex);
            }
        }



        // Get all records including soft-deleted entities
        public async Task<IQueryable<T>> GetAllIncludingDeletedAsync()
        {
            try
            {
                return Context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all records, including deleted ones.", ex);
            }
        }


        // Get all records including soft-deleted entities by ID
        public Task<IQueryable<T>> GetAllIncludingDeletedAsync(Guid Id)
        {
            try
            {
                return (Task<IQueryable<T>>)Context.Set<T>().Where(e => EF.Property<Guid>(e, "Id") == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity by name: {Id}.", ex);
            }
        }


        // Get a record by ID, excluding soft-deleted entities
        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await Context.Set<T>().FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id && EF.Property<bool>(e, "IsDeleted") == false);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity by name: {id}.", ex);
            }
        }





        // Hard delete an entity (remove permanently)
        public async Task HardDeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    Context.Remove(entity);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Entity not found for deletion.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the record with ID {id}.", ex);
            }
        }

        public async Task<bool> Terminate(Guid contractId)
        {
            try
            {
                // Retrieve the contract from the database using the contractId
                var contract = await Context.Set<T>().FindAsync(contractId);

                // Check if the contract exists
                if (contract == null)
                {
                    return false; // Contract not found
                }

                // Use dynamic to access the IsDeleted property
                var deletedEntity = contract as dynamic;
                deletedEntity.IsDeleted = true; // Set IsDeleted to true
                deletedEntity.DeletedOn = DateTime.UtcNow; // Optional: Track the deletion date

                // Save the changes to the database
                await Context.SaveChangesAsync();

                return true; // Indicate that the termination was successful
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while terminating the contract with ID {contractId}.", ex);
            }
        }


        // Insert a new entity
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




        // Save changes to the database
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



        // Soft delete an entity by setting IsDeleted to true
        public async Task SoftDeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    // Assuming the entity has an IsDeleted property
                    var deletedEntity = entity as dynamic; // Use dynamic to access the IsDeleted property
                    deletedEntity.IsDeleted = true; // Set IsDeleted to true

                    await SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Entity not found for soft deletion.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during soft deletion for entity with ID {id}.", ex);
            }
        }

        public async Task RestoreSoftDeletedAsync(Guid id)
        {

            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    var deletedEntity = entity as dynamic; // Use dynamic to access the IsDeleted property
                    deletedEntity.IsDeleted = false; // Set IsDeleted to true

                    await SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Entity not found for soft deletion.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred during soft deletion for entity with ID {id}.", ex);
            }
        }




        // Update an existing entity
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


        // Method to get by unique property name
        public async Task<T> GetByUniqueAsync(string uniqueString, string propertyName)
        {
            // Create a parameter expression for the type T
            var parameter = Expression.Parameter(typeof(T), "u");

            // Create a member expression to access the property by name
            var property = Expression.Property(parameter, propertyName);

            // Create a constant expression for the uniqueString
            var constant = Expression.Constant(uniqueString);

            // Create a binary expression to represent the equality check
            var equality = Expression.Equal(property, constant);

            // Create the final lambda expression
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            // Execute the query using the lambda expression
            var existingUser = await Context.Set<T>().FirstOrDefaultAsync(lambda);

            return existingUser;
        }




        public async Task VerifyUser(Guid Id)
        {
            try
            {
                var entity = await GetByIdAsync(Id);
                if (entity != null)
                {
                    var deletedEntity = entity as dynamic;
                    deletedEntity.IsVerified = true;

                    await SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Entity not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while Verifying for entity with ID {Id}.", ex);
            }
        }
    }
}