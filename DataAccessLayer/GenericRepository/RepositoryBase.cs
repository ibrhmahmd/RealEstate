using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
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

        public async Task<PagedResult<T>> GetFilteredAndPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> filter = null)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>().AsNoTracking();

                // Apply the filter if present
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                query = query.Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                             .OrderBy(e => EF.Property<DateTime?>(e, "CreatedOn") ?? DateTime.MinValue);

                var pagedResult = await query.ToPagedResultAsync(pageNumber, pageSize);

                return pagedResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving filtered and paged records.", ex);
            }
        }


        // Get all Items in Paged list
        public async Task<PagedResult<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = Context.Set<T>().AsNoTracking()
                                    .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                                    .OrderBy(e => EF.Property<int>(e, "CreatedOn")); // Ensure ordering to avoid paging inconsistencies

                return await query.ToPagedResultAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving paged records.", ex);
            }
        }


        // Get all Items in Paged list
        public async Task<PagedResult<T>> GetAllPropertiesForUserPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = Context.Set<T>().AsNoTracking()
                                    .Where(e => EF.Property<bool>(e, "IsDeleted") == false &&
                                                EF.Property<bool>(e, "IsAvailable") == true &&
                                                EF.Property<bool>(e, "IsOccupied") == false)

                                    .OrderBy(e => EF.Property<int>(e, "CreatedOn"));

                return await query.ToPagedResultAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving paged records.", ex);
            }
        }
        public async Task<PagedResult<T>> GetLatestPropertiesAsync(int count , int pageNumber, int pageSize)
        {
            // Fetch properties from the database and order by the CreatedOn property descending
            try
            {
                var query = Context.Set<T>().AsNoTracking()
           .Where(e => EF.Property<bool>(e, "IsAvailable") == true)
           .OrderByDescending(e => EF.Property<DateTime>(e, "CreatedOn"));
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



        //// Soft delete an entity by setting IsDeleted to true
        //public async Task SoftDeleteAsync(Guid id)
        //{
        //    try
        //    {
        //        var entity = await GetByIdAsync(id);
        //        if (entity != null)
        //        {
        //            // Assuming the entity has an IsDeleted property
        //            var deletedEntity = entity as dynamic; // Use dynamic to access the IsDeleted property
        //            deletedEntity.IsDeleted = true; // Set IsDeleted to true
        //            deletedEntity.DeletedOn = DateTime.UtcNow; // Optional: Track the deletion date

        //            await SaveChangesAsync();
        //        }
        //        else
        //        {
        //            throw new Exception("Entity not found for soft deletion.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"An error occurred during soft deletion for entity with ID {id}.", ex);
        //    }
        //}

        // Soft delete an entity by setting IsAvailable to false (or equivalent soft delete marker)
        public async Task SoftDeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    // Check if the entity has the 'IsAvailable' property (assuming soft delete works with this field)
                    var entityType = entity.GetType();
                    var isAvailableProperty = entityType.GetProperty("IsAvailable");

                    if (isAvailableProperty != null)
                    {
                        // Set IsAvailable to false to "soft delete" the entity
                        isAvailableProperty.SetValue(entity, false);  // Soft delete logic here

                        // Optionally, track when the entity was deleted, if needed
                        var deletedOnProperty = entityType.GetProperty("DeletedOn");
                        if (deletedOnProperty != null)
                        {
                            deletedOnProperty.SetValue(entity, DateTime.UtcNow);
                        }

                        // Save the changes to the database
                        await SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Entity does not have an 'IsAvailable' property to mark as deleted.");
                    }
                }
                else
                {
                    throw new Exception("Entity not found for soft deletion.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use your logging mechanism, e.g., _logger.LogError)
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

        public async Task<bool> IsUserVerified(Guid Id)
        {
            try
            {
                var entity = await GetByIdAsync(Id);
                if (entity != null)
                {
                    var Entity = entity as dynamic;
                    if (Entity.IsVerified == true) return true;
                    else return false;
                }
                else
                {
                    throw new Exception("Entity not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking Verifecation of the user with ID {Id}.", ex);
            }
        }

        public async Task Archive(Guid contractId)
        {
            // Find the contract by ID
            var contract = await Context.Contracts.FindAsync(contractId);
            if (contract == null)
            {
                throw new Exception("Contract not found.");
            }

            // Set the IsArchived property to true
            contract.IsArcheives = true;

            // Update the contract in the database
            Context.Contracts.Update(contract);
            await Context.SaveChangesAsync();
        }



        public async Task<PagedResult<T>> GetArchivedContractsAsync(int pageNumber, int pageSize)
        {
            // Ensure that the type T has an IsArchived property using reflection
            var query = Context.Set<T>().Where(e => EF.Property<bool>(e, "IsArcheives") == true)
                                         .OrderBy(e => EF.Property<int>(e, "CreatedOn"));

            return await query.ToPagedResultAsync(pageNumber, pageSize);
        }

        public async Task<PagedResult<T>> GetAcceptedContractsAsync(int pageNumber, int pageSize)
        {
            // Ensure that the type T has an IsArchived property using reflection
            var query = Context.Set<T>()
                .Where(e => EF.Property<bool>(e, "IsArcheives") == false &&
                            EF.Property<bool>(e, "IsAccepted") == true &&
                            EF.Property<bool>(e, "IsTerminated") == false)
                .OrderBy(e => EF.Property<int>(e, "CreatedOn"));
            return await query.ToPagedResultAsync(pageNumber, pageSize);
        }


        public async Task<PagedResult<T>> GetTerminatedContractsAsync(int pageNumber, int pageSize)
        {
            // Ensure that the type T has an IsArchived property using reflection
            var query = Context.Set<T>()
                .Where(e => EF.Property<bool>(e, "IsTerminated") == true || EF.Property<bool>(e, "IsDeclined") == true)
                .OrderBy(e => EF.Property<int>(e, "CreatedOn"));
            return await query.ToPagedResultAsync(pageNumber, pageSize);
        }



        public async Task UnArchive(Guid contractId)
        {
            var contract = await Context.Contracts.FindAsync(contractId);
            if (contract == null)
            {
                throw new Exception("Contract not found.");
            }

            // Set the IsArchived property to true
            contract.IsArcheives = true;

            // Update the contract in the database
            Context.Contracts.Update(contract);
            await Context.SaveChangesAsync();
        }


        public async Task Accept(Guid contractId)
        {
            // Find the contract by ID
            var contract = await Context.Contracts.FindAsync(contractId);

            if (contract == null)
            {
                throw new Exception("Contract not found.");
            }
            else
            {
                contract.IsAccepted = true;
                contract.AcceptedOn = DateTime.Now;
                Context.Contracts.Update(contract);

                await Context.SaveChangesAsync();
            }

        }

        public async Task<bool> Terminate(Guid contractId)
        {
            try
            {
                var contract = await Context.Set<T>().FindAsync(contractId);

                if (contract == null)
                {
                    return false; // Contract not found
                }

                var Entity = contract as dynamic;
                Entity.IsTerminated = true;

                await Context.SaveChangesAsync();

                return true; // Indicate that the termination was successful
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while terminating the contract with ID {contractId}.", ex);
            }
        }
    }
}