using AutoMapper;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper , UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Get all users
        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync(1,5);

            return users.ToList(); 
        }


        // Get all users including soft deleted
        public async Task<List<User>> GetAllUsersIncludingDeletedAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllIncludingDeletedAsync();
            return (List<User>)users; // No mapping needed if returning the entity directly
        }

        // Get user by ID
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user; // Return the User entity directly
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

            // Return the newly created User entity with its ID populated
            return user;
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
            var users = await _unitOfWork.UserRepository.GetAllAsync(1,5);
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

    }
}
