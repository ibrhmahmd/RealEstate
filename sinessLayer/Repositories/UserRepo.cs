using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepo : IRepository<UserDTO>
    {
        private readonly MyDbContext _context;
        private readonly DbSet<User> _dbset;
        private readonly IMapper _mapper;


        public UserRepo(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbset = _context.Set<User>();
        }



        public async Task<IQueryable<UserDTO>> GetAllAsync()
        {
            var users = await _dbset
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return users.Select(user => _mapper.Map<UserDTO>(user)).AsQueryable();
        }



        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _dbset
                .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

            return _mapper.Map<UserDTO>(user);
        }



        public async Task<UserDTO> GetByNameAsync(string username)
        {
            var user = await _dbset
               .SingleOrDefaultAsync(u => u.UserName == username && !u.IsDeleted);

            return _mapper.Map<UserDTO>(user);
        }


        public async Task HardDeleteAsync(Guid id)
        {
            var user = await _dbset.SingleOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _dbset.Remove(user);
                await SaveChangesAsync();
            }
        }

        
        public async Task InsertAsync(UserDTO entity)
        {
            try
            {
                var user = _mapper.Map<User>(entity);
                if (user != null)
                {
                    await _dbset.AddAsync(user);
                    await SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred while inserting the user", ex);
            }
        }

        public async Task UpdateAsync(UserDTO entity)
        {
            try
            {
                var existingUser = await _dbset.SingleOrDefaultAsync(u => u.Id == entity.Id && !u.IsDeleted);
                if (existingUser != null)
                {
                    _mapper.Map(entity, existingUser); 
                    _dbset.Update(existingUser);
                    await SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred while updating the user", ex);
            }
        }


        public async Task SoftDeleteAsync(Guid id)
        {
            var user = await _dbset.SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
            if (user != null)
            {
                user.IsDeleted = true;
                _dbset.Update(user);
                await SaveChangesAsync();
            }
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
