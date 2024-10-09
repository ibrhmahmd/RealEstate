using AutoMapper;
using Azure;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Added for ILogger

namespace BusinessLayer.Services
{
    public class ContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PropertyService _propertyService;
        private readonly ILogger<ContractService> _logger; // Added for ILogger

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper, PropertyService propertyService, ILogger<ContractService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _propertyService = propertyService;
            _logger = logger; // Added for ILogger
        }

        // Get all Contracts
        public async Task<PagedResult<ContractDTO>> GetAllContractsAsync(int pageNumber, int pageSize)
        {
            var contractsPaged = await _unitOfWork.ContractsRepository.GetAllPagedAsync(pageNumber, pageSize);
       
            var ContractDTOs = contractsPaged.Items.Where(c => c.IsArcheives == false).ToList().Select(contract => new ContractDTO
            {
                Id = contract.Id,
                ContractType = contract.ContractType,
                AgentId = contract.AgentId,
                EndDate = contract.EndDate,
                TotalAmount = contract.TotalAmount,
                IsTerminated = contract.IsTerminated,
                PropertyLocation = contract.PropertyLocation,

            }).ToList();
            return new PagedResult<ContractDTO>
            {
                Items = ContractDTOs,
                CurrentPage = contractsPaged.CurrentPage,
                PageSize = contractsPaged.PageSize,
                TotalRecords = contractsPaged.TotalRecords
            };
        }
  
        public async Task ArchiveContract(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);

            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} was not found.");
            }

            contract.IsArcheives = true; // Mark contract as archived
            await _unitOfWork.SaveAsync(); // Save changes using UnitOfWork
        }

        public async Task<List<Contract>> GetArchivedContractsAsync()
        {
            return await _unitOfWork.ContractsRepository.GetArchivedContractsAsync();
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


            await _propertyService.PropertyOccupiedAsync(contract.PropertyId);

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

        public async Task TerminateAsync(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} not found.");
            }

            await _unitOfWork.ContractsRepository.Terminate(id);
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




        public async Task<ContractDTO> ProcessContractAsync(Guid propertyId)
        {
            var property = await _unitOfWork.PropertiesRepository.GetByIdAsync(propertyId);

            if (property == null)
            {
                _logger.LogError($"Property with ID {propertyId} not found.");
                throw new KeyNotFoundException($"Property with ID {propertyId} not found.");
            }

            ValidatePropertyPrice(property.Price);

            var contractModel = CreateBaseContractModel(property);

            if (property.Status.HasValue)
            {
                ProcessContractByStatus(contractModel, property);
            }
            else
            {
                _logger.LogError($"Property status is not defined for property ID {propertyId}.");
                throw new InvalidOperationException("Property status is not defined.");
            }

            return contractModel;
        }




        private void ValidatePropertyPrice(decimal price)
        {
            if (price <= 0 || price > 1_000_000_000) // Adjust the upper limit as needed
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Property price must be positive and within a reasonable range.");
            }
        }

        private ContractDTO CreateBaseContractModel(Property property)
        {
            return new ContractDTO
            {
                PropertyId = property.Id,
                PropertyLocation = property.Location,
                IsFurnished = property.IsFUrnished,
                Rooms = property.Rooms,
                ContractType = property.Status.ToString(),
                TotalAmount = property.Price
            };
        }

        private void ProcessContractByStatus(ContractDTO contractModel, Property property)
        {
            switch (property.Status.Value)
            {
                case PropertStatus.Lease:
                    ProcessLeaseContract(contractModel, property.Price);
                    break;

                case PropertStatus.Ownership:
                    ProcessOwnershipContract(contractModel, property.Price);
                    break;

                default:
                    _logger.LogError($"Unsupported property status: {property.Status.Value} for property ID {property.Id}");
                    throw new InvalidOperationException($"Unsupported property status: {property.Status.Value}");
            }
        }
 


        private void ProcessLeaseContract(ContractDTO contractModel, decimal price)
        {
            contractModel.RecurringPaymentFrequency = "Monthly";
            contractModel.RecurringPaymentAmount = Math.Round(price / 12, 2);
            contractModel.InitialPayment = Math.Round(price / 6, 2);
        }

        private void ProcessOwnershipContract(ContractDTO contractModel, decimal price)
        {
            contractModel.RecurringPaymentFrequency = "Quarterly";
            contractModel.RecurringPaymentAmount = Math.Round(price / 4, 2);
            contractModel.InitialPayment = Math.Round(price * 0.75m, 2);
        }
    }
}