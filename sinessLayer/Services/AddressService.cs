using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get all Addresses
        public async Task<IQueryable<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _unitOfWork.AddressesRepository.GetAllAsync();
            return _mapper.Map<IQueryable<AddressDTO>>(addresses);
        }


        // Get all Addresses including soft deleted
        public async Task<IQueryable<AddressDTO>> GetAllAddressesIncludingDeletedAsync()
        {
            var addresses = await _unitOfWork.AddressesRepository.GetAllIncludingDeletedAsync();
            return _mapper.Map<IQueryable<AddressDTO>>(addresses);
        }



        // Get address by ID
        public async Task<AddressDTO> GetAddressByIdAsync(Guid id)
        {
            var address = await _unitOfWork.AddressesRepository.GetByIdAsync(id);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }
            return _mapper.Map<AddressDTO>(address);
        }



        // Create a new address
        public async Task<AddressDTO> CreateContractAsync(AddressDTO addressDto)
        {
            // address AutoMapper to map AddressDTO to Contract entity
            var address = _mapper.Map<Address>(addressDto);

            await _unitOfWork.AddressesRepository.InsertAsync(address);
            await _unitOfWork.SaveAsync();

            // Return the mapped AddressDTO (this might return a address with an ID if you need it)
            return _mapper.Map<AddressDTO>(address);
        }



        // Update a address
        public async Task<AddressDTO> UpdateContractAsync(AddressDTO addressDto)
        {
            var existingAddress = await _unitOfWork.AddressesRepository.GetByIdAsync(addressDto.ID);
            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with ID {addressDto.ID} not found.");
            }

            // Address AutoMapper to update the existing Address entity
            var address = _mapper.Map(addressDto, existingAddress);

            await _unitOfWork.AddressesRepository.UpdateAsync(address);
            await _unitOfWork.SaveAsync();

            // Return the mapped PaymentDTO
            return _mapper.Map<AddressDTO>(existingAddress);
        }




        // Soft delete a address
        public async Task SoftDeleteAddressAsync(Guid id)
        {
            var address = await _unitOfWork.AddressesRepository.GetByIdAsync(id);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }

            await _unitOfWork.AddressesRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }




        // Hard delete a address
        public async Task HardDeleteAdressAsync(Guid id)
        {
            var address = await _unitOfWork.AddressesRepository.GetByIdAsync(id);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }

            await _unitOfWork.AddressesRepository.HardDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }



        // Restore a soft deleted address
        public async Task RestoreContractAsync(Guid id)
        {
            var address = await _unitOfWork.AddressesRepository.GetByIdAsync(id); // Ensure this gets the address entity
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }

            if (!address.IsDeleted) // Accessing IsDeleted from the address entity
            {
                throw new InvalidOperationException($"Address with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.AddressesRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }

    }
}