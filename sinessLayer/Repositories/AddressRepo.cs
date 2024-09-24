using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.DTOModels;

namespace DataAccessLayer.Repositories
{
    public class AddressRepo : IRepository<AddressDTO>
    {

        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Address> _dbset;

        public AddressRepo(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbset = _context.Set<Address>();
        }



        public async Task<IQueryable<AddressDTO>> GetAllAsync()
        {
            var addresses = await _dbset
                .Where(p => !p.IsDeleted)
                .ToListAsync();
            return addresses.Select(p => _mapper.Map<AddressDTO>(p)).AsQueryable();
        }

        public async Task<AddressDTO> GetByIdAsync(Guid Id)
        {
            var adress = await _dbset
                .SingleOrDefaultAsync(a=>a.ID == Id && !a.IsDeleted);
            return _mapper.Map<AddressDTO>(adress);
        }

        public Task<AddressDTO> GetByNameAsync(string name)
        {

            throw new NotImplementedException();
        }

        public Task HardDeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(AddressDTO entity)
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

        public Task UpdateAsync(AddressDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
