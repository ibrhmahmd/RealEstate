using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PropertyRepo : IRepository<PropertyDTO>
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Property> _dbset;

        public PropertyRepo(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbset = _context.Set<Property>();
        }




        public async Task<IQueryable<PropertyDTO>> GetAllAsync()
        {
            var properties = await _dbset
                .Where(p => !p.IsDeleted)
                .ToListAsync();
            return properties.Select(p => _mapper.Map<PropertyDTO>(p)).AsQueryable();
        }



        public async Task<PropertyDTO> GetByIdAsync(Guid id)
        {
            var property = await _dbset
                .Include(p => p.Location) // Include Address if necessary
                .Include(p => p.Contracts) // Include Contracts if necessary
                .SingleOrDefaultAsync(p => p.ID == id && !p.IsDeleted);
            return _mapper.Map<PropertyDTO>(property);
        }




        public async Task<PropertyDTO> GetByNameAsync(string name)
        {
            var property = await _dbset
                .Include(p => p.Location) // Include Address if necessary
                .Include(p => p.Contracts) // Include Contracts if necessary
                .SingleOrDefaultAsync(p => p.Name == name && !p.IsDeleted);
            return _mapper.Map<PropertyDTO>(property);
        }



        //public async Task<IEnumerable<PropertyDTO>> GetByPredicateAsync(Expression<Func<Property, bool>> predicate)
        //{
        //    var properties = await _dbset
        //        .Where(predicate)
        //        .Where(p => !p.IsDeleted)
        //        .ToListAsync();
        //    return properties.Select(p => _mapper.Map<PropertyDTO>(p));
        //}


        public async Task InsertAsync(PropertyDTO entity)
        {
            var property = _mapper.Map<Property>(entity);
            await _dbset.AddAsync(property);
            await SaveChangesAsync();
        }



        public async Task UpdateAsync(PropertyDTO entity)
        {
            var existingProperty = await _dbset
                .SingleOrDefaultAsync(p => p.ID == entity.ID && !p.IsDeleted);
            if (existingProperty != null)
            {
                _mapper.Map(entity, existingProperty);
                _dbset.Update(existingProperty);
                await SaveChangesAsync();
            }
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            var property = await _dbset
                .SingleOrDefaultAsync(p => p.ID == id && !p.IsDeleted);
            if (property != null)
            {
                property.IsDeleted = true;
                _dbset.Update(property);
                await SaveChangesAsync();
            }
        }

        public async Task HardDeleteAsync(Guid id)
        {
            var property = await _dbset
                .SingleOrDefaultAsync(p => p.ID == id);
            if (property != null)
            {
                _dbset.Remove(property);
                await SaveChangesAsync();
            }
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
