using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper, MyDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = dbContext;
        }


        // Get all properties
        public async Task<PagedResult<PropertyDTO>> GetAllPropertiesAsync(int pageNumber, int pageSize)
        {
            var propertiesPaged = await _unitOfWork.PropertiesRepository.GetAllPagedAsync(pageNumber, pageSize);

            var propertyDTOs = propertiesPaged.Items.Select(property => new PropertyDTO
            {
                Id = property.Id,
                Name = property.Name,
                PropertyPictureUrl=property.PropertyPictureUrl,
                Location = property.Location,
                Description = property.Description,
                Area = property.Area,
                Status = property.Status,
                Price = property.Price,
                Type = property.Type,
            }).ToList();




            return new PagedResult<PropertyDTO>
            {
                Items = propertyDTOs,
                CurrentPage = propertiesPaged.CurrentPage,
                PageSize = propertiesPaged.PageSize,
                TotalRecords = propertiesPaged.TotalRecords
            };
        }




        public async Task<List<PropertyDTO>> GetAvailablePropertiesAsync()
        {
            var properties = await _context.Properties
                .Where(p => p.IsAvailable == true && p.IsOccupied == false && p.IsDeleted ==false).ToListAsync();
            return _mapper.Map<List<PropertyDTO>>(properties);
        }





        // Get all properties including soft deleted
        public async Task<IQueryable<PropertyDTO>> GetAllPropertiesIncludingDeletedAsync()
        {
            var properties = await _unitOfWork.PropertiesRepository.GetAllIncludingDeletedAsync();
            return _mapper.Map<IQueryable<PropertyDTO>>(properties);
        }



        // Get property by Id
        public async Task<PropertyDTO> GetPropertyByIdAsync(Guid Id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(Id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with Id {Id} not found.");
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

            // Return the mapped PropertyDTO (this might return a property with an Id if needed)
            return _mapper.Map<PropertyDTO>(property);
        }



        // Update an existing property
        public async Task<PropertyDTO> UpdatePropertyAsync(PropertyDTO propertyDto)
        {
            var existingProperty = await _unitOfWork.PropertiesRepository.GetByIdAsync(propertyDto.Id);
            if (existingProperty == null)
            {
                throw new KeyNotFoundException($"Property with Id {propertyDto.Id} not found.");
            }

            _mapper.Map(propertyDto, existingProperty);

            await _unitOfWork.PropertiesRepository.UpdateAsync(existingProperty);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<PropertyDTO>(existingProperty);
        }


        // Soft delete a property
        public async Task SoftDeletePropertyAsync(Guid Id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(Id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with Id {Id} not found.");
            }

            await _unitOfWork.PropertiesRepository.SoftDeleteAsync(Id);
            await _unitOfWork.SaveAsync();
        }

        // Hard delete a property
        public async Task HardDeletePropertyAsync(Guid Id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(Id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with Id {Id} not found.");
            }

            await _unitOfWork.PropertiesRepository.HardDeleteAsync(Id);
            await _unitOfWork.SaveAsync();
        }

        // Restore a soft deleted property
        public async Task RestorePropertyAsync(Guid Id)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(Id);
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with Id {Id} not found.");
            }

            if (!property.IsDeleted)
            {
                throw new InvalidOperationException($"Property with Id {Id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.PropertiesRepository.RestoreSoftDeletedAsync(Id);
            await _unitOfWork.SaveAsync();
        }



        public async Task PropertyOccupiedAsync(Guid id)
        {
            // Retrieve the selected property using the provided ID
            var selectedProperty = await _unitOfWork.PropertiesRepository.GetByIdAsync(id);

            // Check if the property exists
            if (selectedProperty != null)
            {
                // Set the property as unavailable
                selectedProperty.IsAvailable = false;

                // Update the property in the repository
                await _unitOfWork.PropertiesRepository.UpdateAsync(selectedProperty);

                // Save changes to the database
                await _unitOfWork.SaveAsync();
            }
        }



        // Helper method to check if a property already exists by some unique identifier
        private async Task<bool> IsPropertyExistsAsync(string propertyName)
        {
            var existingProperty = await _unitOfWork.PropertiesRepository.GetByUniqueAsync(propertyName, "Name");
            return existingProperty != null;
        }

        


    }
}