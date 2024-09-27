using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // Get all properties
        public async Task<List<PropertyDTO>> GetAllPropertiesAsync()
        {
            var properties = await _unitOfWork.PropertiesRepository.GetAllAsync();
            return _mapper.Map<List<PropertyDTO>>(properties);
        }





        // Get all properties including soft deleted
        public async Task<IQueryable<PropertyDTO>> GetAllPropertiesIncludingDeletedAsync()
        {
            var properties = await _unitOfWork.PropertiesRepository.GetAllIncludingDeletedAsync();
            return _mapper.Map<IQueryable<PropertyDTO>>(properties);
        }



        // Get property by ID
        public async Task<PropertyDTO> GetPropertyByIdAsync(Guid id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with ID {id} not found.");
            }
            return _mapper.Map<PropertyDTO>(property);
        }



        // Create a new property
        public async Task<PropertyDTO> CreatePropertyAsync(PropertyDTO propertyDto)
        {
            // Use AutoMapper to map PropertyDTO to Property entity
            var property = _mapper.Map<Property>(propertyDto);

            await _unitOfWork.PropertiesRepository.InsertAsync(property);
            await _unitOfWork.SaveAsync();

            // Return the mapped PropertyDTO (this might return a property with an ID if needed)
            return _mapper.Map<PropertyDTO>(property);
        }



        // Update an existing property
        public async Task<PropertyDTO> UpdatePropertyAsync(PropertyDTO propertyDto)
        {
            var existingProperty = await _unitOfWork.PropertiesRepository.GetByIdAsync(propertyDto.Id);
            if (existingProperty == null)
            {
                throw new KeyNotFoundException($"Property with ID {propertyDto.Id} not found.");
            }

            _mapper.Map(propertyDto, existingProperty);

            await _unitOfWork.PropertiesRepository.UpdateAsync(existingProperty);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<PropertyDTO>(existingProperty);
        }


        // Soft delete a property
        public async Task SoftDeletePropertyAsync(Guid id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with ID {id} not found.");
            }

            await _unitOfWork.PropertiesRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        // Hard delete a property
        public async Task HardDeletePropertyAsync(Guid id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with ID {id} not found.");
            }

            await _unitOfWork.PropertiesRepository.HardDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        // Restore a soft deleted property
        public async Task RestorePropertyAsync(Guid id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(id); 
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with ID {id} not found.");
            }

            if (!property.IsDeleted) 
            {
                throw new InvalidOperationException($"Property with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.PropertiesRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }





        // Helper method to check if a property already exists by some unique identifier
        private async Task<bool> IsPropertyExistsAsync(string propertyName)
        {
            var existingProperty = await _unitOfWork.PropertiesRepository.GetByUniqueAsync(propertyName, "Name");
            return existingProperty != null;
        }
    }
}
