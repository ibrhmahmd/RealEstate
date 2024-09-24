using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
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
    }
}
