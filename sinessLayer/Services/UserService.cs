using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork, IMapper mapper, MyDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }


        // Get all users
        public async Task<IQueryable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IQueryable<UserDTO>>(users);
        }




        // Get all users including soft deleted
        public async Task<IQueryable<UserDTO>> GetAllUsersIncludingDeletedAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllIncludingDeletedAsync();
            return _mapper.Map<IQueryable<UserDTO>>(users);
        }





        // Get user by ID
        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return _mapper.Map<UserDTO>(user);
        }




        // Create a new user
        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            if (await IsEmailTakenAsync(userDto.Email))
            {
                throw new InvalidOperationException($"Email {userDto.Email} is already in use.");
            }

            // Use AutoMapper to map UserDTO to User entity
            var user = _mapper.Map<User>(userDto);

            // Hash the password before saving it
            if (!string.IsNullOrWhiteSpace(userDto.PasswordHash))
            {
                user.PasswordHash = HashPassword(userDto.PasswordHash);
            }

            await _unitOfWork.UserRepository.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            // Return the mapped UserDTO (this might return a user with an ID if you need it)
            return _mapper.Map<UserDTO>(user);
        }

        // Update a user
        public async Task<UserDTO> UpdateUserAsync(UserDTO userDto)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(userDto.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userDto.Id} not found.");
            }

            // Check if email has changed and is already taken
            if (existingUser.Email != userDto.Email && await IsEmailTakenAsync(userDto.Email))
            {
                throw new InvalidOperationException($"Email {userDto.Email} is already in use.");
            }

            // If the password is being updated, hash it
            if (!string.IsNullOrWhiteSpace(userDto.PasswordHash))
            {
                existingUser.PasswordHash = HashPassword(userDto.PasswordHash);
            }

            // Use AutoMapper to update the existing User entity
            _mapper.Map(userDto, existingUser);

            await _unitOfWork.UserRepository.UpdateAsync(existingUser);
            await _unitOfWork.SaveAsync();

            // Return the mapped UserDTO
            return _mapper.Map<UserDTO>(existingUser);
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
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id); // Ensure this gets the user entity
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            if (!user.IsDeleted) // Accessing IsDeleted from the User entity
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


        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;

        }



        public async Task<UserDTO> AuthenticateUserAsync(string email, string password)
        {
            // Find the user by email
            var user = await GetByEmail(email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found."); // Throw an exception if user not found
            }

            // Verify the password using the custom VerifyPassword method
            var isPasswordValid = VerifyPassword(password, user.PasswordHash);

            // Check if the password is correct
            if (isPasswordValid)
            {
                // Map the User entity to UserDTO and return
                return _mapper.Map<UserDTO>(user);
            }

            // Throw an exception if the password is incorrect
            throw new UnauthorizedAccessException("Invalid password.");
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





    }
}
