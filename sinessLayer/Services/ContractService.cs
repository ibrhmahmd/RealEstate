using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get all Contracts
        public async Task<List<ContractDTO>> GetAllContractsAsync()
        {
            var contracts = await _unitOfWork.ContractsRepository.GetAllAsync();
            return _mapper.Map<List<ContractDTO>>(contracts);

        }




        // Get all contracts including soft deleted
        public async Task<IQueryable<ContractDTO>> GetAllContractsIncludingDeletedAsync()
        {
            var contracts = await _unitOfWork.ContractsRepository.GetAllIncludingDeletedAsync();
            return _mapper.Map<IQueryable<ContractDTO>>(contracts);
        }



        // Get contract by ID
        public async Task<ContractDTO> GetContractByIdAsync(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} not found.");
            }
            return _mapper.Map<ContractDTO>(contract);
        }



        // Create a new contract
        public async Task<ContractDTO> CreateContractAsync(ContractDTO contractDto)
        {
            // contract AutoMapper to map ContractDTO to Contract entity
            var contract = _mapper.Map<Contract>(contractDto);

            await _unitOfWork.ContractsRepository.InsertAsync(contract);
            await _unitOfWork.SaveAsync();

            // Return the mapped ContractDTO (this might return a contract with an ID if you need it)
            return _mapper.Map<ContractDTO>(contract);
        }



        // Update a contract
        public async Task<ContractDTO> UpdateContractAsync(ContractDTO contractDto)
        {
            var existingContract = await _unitOfWork.ContractsRepository.GetByIdAsync(contractDto.Id);
            if (existingContract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {contractDto.Id} not found.");
            }

            // Contract AutoMapper to update the existing Contract entity
            _mapper.Map(contractDto, existingContract);

            await _unitOfWork.ContractsRepository.UpdateAsync(existingContract);
            await _unitOfWork.SaveAsync();

            // Return the mapped ContractDTO
            return _mapper.Map<ContractDTO>(existingContract);
        }




        // Soft delete a contract
        public async Task SoftDeleteContractAsync(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} not found.");
            }

            await _unitOfWork.ContractsRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }




        // Hard delete a contract
        public async Task HardDeleteContractAsync(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} not found.");
            }

            await _unitOfWork.ContractsRepository.HardDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }



        // Restore a soft deleted contract
        public async Task RestoreContractAsync(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id); // Ensure this gets the contract entity
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} not found.");
            }

            if (!contract.IsDeleted) // Accessing IsDeleted from the Contract entity
            {
                throw new InvalidOperationException($"Contract with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.ContractsRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }

    }
}