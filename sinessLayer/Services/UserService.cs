using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            await _unitOfWork.UserRepository.InsertAsync(userDto);
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
            var existingUser = await _unitOfWork.UserRepository.GetByUniqueAsync(email,"Email");
            return existingUser != null;
        }
        public async Task<UserDTO> AuthenticateUserAsync(string email, string password)
        {
            // First await the GetAllAsync method to get the IQueryable<UserDTO>
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var user = await users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return null; // User not found
            }

            // Verify the password
            if (VerifyPassword(password, user.PasswordHash))
            {
                // Password is correct, return the user DTO
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                    // Add any other properties you want to return
                };
            }

            return null; // Password is incorrect
        }
        private bool VerifyPassword(string password, string storedHash)
        {
            // Extract the salt from the stored hash
            byte[] saltBytes = Convert.FromBase64String(storedHash.Split('.')[0]);

            // Hash the input password with the extracted salt
            string inputHash = HashPassword(password, saltBytes);

            // Compare the computed hash with the stored hash
            return inputHash == storedHash;
        }

        private string HashPassword(string password, byte[] salt = null)
        {
            if (salt == null)
            {
                // Generate a new salt if one is not provided
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }

            // Derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            // Combine the salt and hash
            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

    }
}
