using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, MyDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }







        // Get all users
        public async Task<PagedResult<UserDTO>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var usersPaged = await _unitOfWork.UserRepository.GetAllPagedAsync(pageNumber, pageSize);
            var userDTOs = usersPaged.Items.Select(user => new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                IsVerified = user.IsVerified ?? false // Default to false if null
            }).ToList();

            return new PagedResult<UserDTO>
            {
                Items = userDTOs,
                CurrentPage = usersPaged.CurrentPage,
                PageSize = usersPaged.PageSize,
                TotalRecords = usersPaged.TotalRecords
            };
        }


        // Get all users including soft deleted
        public async Task<List<User>> GetAllUsersIncludingDeletedAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllIncludingDeletedAsync();
            return (List<User>)users; // No mapping needed if returning the entity directly
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user; // Return the user entity directly
        }






        public async Task<User> CreateUserAsync(User user)
        {
            if (await IsEmailTakenAsync(user.Email))
            {
                throw new InvalidOperationException($"Email {user.Email} is already in use.");
            }

            if (!string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                user.PasswordHash = HashPassword(user.PasswordHash);
            }

            user.SecurityStamp = Guid.NewGuid().ToString();

            // Check if the role exists, if not create it
            if (!await _roleManager.RoleExistsAsync(user.Role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>(user.Role));
                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Could not create role {user.Role}");
                }
            }

            await _unitOfWork.UserRepository.InsertAsync(user);

            var addToRoleResult = await _userManager.AddToRoleAsync(user, user.Role);
            if (!addToRoleResult.Succeeded)
            {
                throw new InvalidOperationException($"Could not add user to role {user.Role}");
            }

            await _unitOfWork.SaveAsync();
            return user;
        }


        public User GetCurrentUser(ClaimsPrincipal userPrincipal)
        {
            // Get the user ID from the claims
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null; // No user is logged in
            }

            // Parse the userId (which is a string) to Guid
            if (Guid.TryParse(userId, out Guid parsedUserId))
            {
                // Fetch the user from the database using the parsed Guid userId
                return _context.Users.SingleOrDefault(e => e.Id == parsedUserId);
            }

            return null; // If the userId cannot be parsed to Guid, return null
        }





        // Update a user
        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }

            // Check if email has changed and is already taken
            if (existingUser.Email != user.Email && await IsEmailTakenAsync(user.Email))
            {
                throw new InvalidOperationException($"Email {user.Email} is already in use.");
            }

            // If the password is being updated, hash it
            if (!string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                existingUser.PasswordHash = HashPassword(user.PasswordHash);
            }

            // Map updated properties to the existing user entity
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.UserPictureUrl = user.UserPictureUrl;
            await _unitOfWork.UserRepository.UpdateAsync(existingUser);
            await _unitOfWork.SaveAsync();

            return existingUser; // Return the updated user entity
        }



        // Soft delete a user
        public async Task SoftDeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            await _unitOfWork.UserRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }


        // Hard delete a user
        public async Task HardDeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            await _unitOfWork.UserRepository.HardDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }


        // Restore a soft deleted user
        public async Task RestoreUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            if (!user.IsDeleted) // Assuming there's an IsDeleted property in the User entity
            {
                throw new InvalidOperationException($"User with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.UserRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }


        // Helper method to check if an email is already taken
        private async Task<bool> IsEmailTakenAsync(string email)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByUniqueAsync(email, "Email");
            return existingUser != null;
        }




        // Authenticate user based on email and password
        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync(1, 5);
            var user = await users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return null; // User not found
            }

            // Verify the password
            if (VerifyPassword(password, user.PasswordHash))
            {
                return user; // Return the User entity if authentication succeeds
            }

            return null; // Password is incorrect
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hashParts = storedHash.Split('.');
            if (hashParts.Length != 2)
            {
                throw new FormatException("Stored password hash is not in the correct format.");
            }

            try
            {
                byte[] saltBytes = Convert.FromBase64String(hashParts[0]);
                string inputHash = HashPassword(password, saltBytes);
                return inputHash == storedHash;
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid format for Base64 string in stored password hash.", ex);
            }
        }

        private string HashPassword(string password, byte[] salt = null)
        {
            if (salt == null)
            {
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }


        public async Task<bool> RegisterUserAsync(string email, string password, string role)
        {
            // Create the user
            var user = new User { Email = email, UserName = email };

            // Hash the password using the custom hashing method
            user.PasswordHash = HashPassword(password);
            user.SecurityStamp = Guid.NewGuid().ToString();

            // Create the user

            await CreateUserAsync(user);

            var result = await GetUserByIdAsync(user.Id);
            var insertionOK = false;

            if (result != user)
                insertionOK = false;
            else
            {
                insertionOK = true;
            }


            if (insertionOK)
            {
                // Assign the Admin role to the user
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }

                // Assign the user to the Admin role
                await _userManager.AddToRoleAsync(user, role);
            }

            return insertionOK;
        }


        // Method to get roles of a user
        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            // Retrieve the user by ID
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new List<string>(); // Return empty list if user not found
            }

            // Get roles for the user
            var roles = await _userManager.GetRolesAsync(user);

            return (List<string>)roles; // Return the list of roles
        }


        public async Task<bool> VerifyUser(Guid id)
        {
            try
            {
                await _unitOfWork.UserRepository.VerifyUser(id);
                await _unitOfWork.SaveAsync();

                var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
                return user != null && user.IsVerified == true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error verifying user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> IsUserVerified(Guid Id)
        {
            var userVerificationState = await _unitOfWork.UserRepository.IsUserVerified(Id);
            return userVerificationState;
        }


        public async Task<(List<PropertyDTO> properties, int totalItems)> GetUserPropertiesAsync(Guid userId, int pageNumber, int pageSize)
        {
            // Define the filter expression to select contracts by userId
            Expression<Func<Contract, bool>> filter = contract => contract.OccupantId == userId;

            var pagedContracts = await _unitOfWork.ContractsRepository
                .GetFilteredAndPagedAsync(pageNumber, pageSize, filter);

            var propertyIds = pagedContracts.Items.Select(c => c.PropertyId).ToList();

            var propertiesQuery = _context.Properties
                .Where(p => propertyIds.Contains(p.Id) && p.IsOccupied == true)
                .AsQueryable();

            var totalItems = pagedContracts.TotalRecords;

            var properties = await propertiesQuery.ToListAsync();

            var propertyDTOs = properties.Select(p => new PropertyDTO
            {
                Id = p.Id,
                Name = p.Name,
                PropertyPictureUrl = p.PropertyPictureUrl,
                Location = p.Location,
                Description = p.Description,
                PropertyProject = p.PropertyProject,
                Area = p.Area,
                Price = p.Price,
                Type = p.Type,
            }).ToList();

            return (propertyDTOs, totalItems);
        }


        public async Task<(List<ContractDTO> Contracts, int TotalItems)> GetUserContractsAsync(Guid userId, int pageNumber, int pageSize)
        {

            Expression<Func<Contract, bool>> filter = contract => contract.OccupantId == userId && contract.IsAccepted == true;

            var pagedContracts = await _unitOfWork.ContractsRepository
                .GetFilteredAndPagedAsync(pageNumber, pageSize, filter);

            var contracts = pagedContracts.Items;

            var contractDTOs = contracts.Select(c => new ContractDTO
            {
                Id = c.Id,
                ContractType = c.ContractType,
                EndDate = c.EndDate,
                TotalAmount = c.TotalAmount,
                PropertyLocation = c.PropertyLocation,
            }).ToList();

            var totalItems = pagedContracts.TotalRecords;

            return (contractDTOs, totalItems);
        }




        public async Task<(List<PropertyDTO> properties, int totalItems)> GetOwnedPropertiesAsync(Guid userId, int pageNumber, int pageSize)
        {
            var propertiesQuery = _context.Contracts
                .Where(c => c.OccupantId == userId)
                .Join(_context.Properties,
                      contract => contract.PropertyId,
                      property => property.Id,
                      (contract, property) => property)
                .Where(p => p.Status == PropertStatus.Ownership)
                .AsQueryable();

            var totalItems = await propertiesQuery.CountAsync();

            var properties = await propertiesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (properties.Select(p => new PropertyDTO
            {
                Id = p.Id,
                Name = p.Name,
                PropertyPictureUrl = p.PropertyPictureUrl,
                Location = p.Location,
                Description = p.Description,
                Area = p.Area,
                Price = p.Price,
                Type = p.Type,
            }).ToList(), totalItems);
        }



        public async Task<(List<PropertyDTO> properties, int totalItems)> GetLeasedPropertiesAsync(Guid userId, int pageNumber, int pageSize)
        {
            var propertiesQuery = _context.Contracts
                .Where(c => c.OccupantId == userId)
                .Join(_context.Properties,
                      contract => contract.PropertyId,
                      property => property.Id,
                      (contract, property) => property)
                .Where(p => p.Status == PropertStatus.Lease)
                .AsQueryable();

            var totalItems = await propertiesQuery.CountAsync();

            var properties = await propertiesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (properties.Select(p => new PropertyDTO
            {
                Id = p.Id,
                Name = p.Name,
                PropertyPictureUrl = p.PropertyPictureUrl,
                Location = p.Location,
                Description = p.Description,
                Area = p.Area,
                Price = p.Price,
                Type = p.Type,
            }).ToList(), totalItems);
        }


    }
}