using AutoMapper;
using Azure;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace BusinessLayer.Services
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PropertyService _propertyService;
        private readonly MyDbContext _Context;
        private readonly ILogger<ContractService> _logger;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper, PropertyService propertyService, ILogger<ContractService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _propertyService = propertyService;
            _logger = logger;
        }


        // Get all Contracts
        public async Task<PagedResult<ContractDTO>> GetAllContractsAsync(int pageNumber, int pageSize)
        {
            var contractsPaged = await _unitOfWork.ContractsRepository.GetAllPagedAsync(pageNumber, pageSize);

            var ContractDTOs = contractsPaged.Items.Where(c => c.IsArcheives == false && c.IsTerminated == false && c.IsAccepted == false).ToList().Select(contract => new ContractDTO
            {
                Id = contract.Id,
                ContractType = contract.ContractType,
                AgentId = contract.AgentId,
                Document=contract.Document,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                TotalAmount = contract.TotalAmount,
                IsTerminated = contract.IsTerminated,
                PropertyLocation = contract.PropertyLocation,
                PropertyName = contract.PropertyName,

            }).ToList();
            return new PagedResult<ContractDTO>
            {
                Items = ContractDTOs,
                CurrentPage = contractsPaged.CurrentPage,
                PageSize = contractsPaged.PageSize,
                TotalRecords = contractsPaged.TotalRecords
            };
        }

        public async Task<PagedResult<ContractDTO>> GetArchivedContractsAsync(int pageNumber, int pageSize)
        {

            var archivedcontract = _mapper.Map<PagedResult<ContractDTO>>(await _unitOfWork.ContractsRepository.GetArchivedContractsAsync(pageNumber, pageSize));

            return archivedcontract;
        }


        public async Task<PagedResult<ContractDTO>> AcceptedContractsAsync(int pageNumber, int pageSize)
        {
            var Acceptedcontract = _mapper.Map<PagedResult<ContractDTO>>(await _unitOfWork.ContractsRepository.GetAcceptedContractsAsync(pageNumber, pageSize));
            return Acceptedcontract;
        }

        public async Task<PagedResult<ContractDTO>> TerminatedContractsAsync(int pageNumber, int pageSize)
        {
            var Terminatedcontract = _mapper.Map<PagedResult<ContractDTO>>(await _unitOfWork.ContractsRepository.GetTerminatedContractsAsync(pageNumber, pageSize));
            return Terminatedcontract;
        }


        public async Task ArchiveContract(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);

            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} was not found.");
            }

            contract.IsArcheives = true;
            await _unitOfWork.SaveAsync();
        }




        public async Task UnArchiveContract(Guid id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);

            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} was not found.");
            }

            contract.IsArcheives = false; // Mark contract as archived
            await _unitOfWork.SaveAsync(); // Save changes using UnitOfWork
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
            // AutoMapper to map ContractDTO to Contract entity
            var contract = _mapper.Map<Contract>(contractDto);
            contract.UpdatedOn = DateTime.Now;

            await _unitOfWork.ContractsRepository.InsertAsync(contract);
            await _unitOfWork.SaveAsync();
            await _propertyService.PropertyNotAvailbleAsync(contract.PropertyId);

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

            // AutoMapper to update the existing Contract entity
            _mapper.Map(contractDto, existingContract);

            existingContract.UpdatedOn = DateTime.Now;
            await _unitOfWork.ContractsRepository.UpdateAsync(existingContract);
            await _unitOfWork.SaveAsync();

            // Return the mapped ContractDTO
            return _mapper.Map<ContractDTO>(existingContract);
        }



        public async Task AcceptContract(Guid Id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(Id);
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {Id} not found.");
            }

            contract.AcceptedOn = DateTime.Now;

            // Assuming PropertyOccupiedAsync sets the property as occupied
            await _propertyService.PropertyOccupiedAsync(contract.PropertyId, contract.OccupantId);
            await _propertyService.PropertyNotAvailbleAsync(contract.PropertyId);
            await _unitOfWork.ContractsRepository.Accept(Id);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeclineContract(Guid Id)
        {
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(Id);
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {Id} not found.");
            }

            await _propertyService.PropertyAvailbleAsync(contract.PropertyId);
            contract.DeclienedOn= DateTime.Now;
            contract.IsDecliened = true;
            contract.UpdatedOn = DateTime.Now;
            
            await _unitOfWork.ContractsRepository.UpdateAsync(contract);
            await _unitOfWork.SaveAsync();
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
            // Retrieve the contract using the provided ID
            var contract = await _unitOfWork.ContractsRepository.GetByIdAsync(id);

            // Check if the contract exists
            if (contract == null)
            {
                throw new KeyNotFoundException($"Contract with ID {id} not found.");
            }

            // Set the IsTerminated property to true
            contract.IsTerminated = true;
            await _propertyService.PropertyAvailbleAsync(contract.PropertyId);

            // Save changes to the database
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


        private ContractDTO CreateBaseContractModel(Property property)
        {
            return new ContractDTO
            {
                PropertyId = property.Id,
                PropertyLocation = property.Location,
                IsFurnished = property.IsFUrnished,
                Rooms = property.Rooms,
                ContractType = property.Status.ToString(),
                TotalAmount = property.Price,
                PropertyName = property.Name,
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

        private void ValidatePropertyPrice(decimal price)
        {
            if (price <= 0 || price > 1_000_000_000) // Adjust the upper limit as needed
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Property price must be positive and within a reasonable range.");
            }
        }






        private void ProcessLeaseContract(ContractDTO contractModel, decimal price)
        {
            contractModel.RecurringPaymentFrequency = "Monthly";
            contractModel.RecurringPaymentAmount = Math.Round(price / 0.5m, 1);
            contractModel.InitialPayment = Math.Round((decimal)(contractModel.RecurringPaymentAmount * 2), 1);
            contractModel.TotalAmount = Math.Round(price, 2);
        }

        private void ProcessOwnershipContract(ContractDTO contractModel, decimal price)
        {
            // Define the recurring payment frequency
            contractModel.RecurringPaymentFrequency = "Quarterly";

            // Set the initial payment as 30% of the total price
            contractModel.InitialPayment = Math.Round(price * 0.3m, 2); // 30% upfront

            // Calculate the remaining amount after the initial payment
            decimal remainingAmount = (decimal)(price - contractModel.InitialPayment);

            // Define how much each recurring payment should be (15% of total price)
            contractModel.RecurringPaymentAmount = Math.Round(price * 0.15m, 2); // Each quarterly payment is 15% of total price

            // Calculate how many quarterly payments are needed to cover the remaining amount
            int numberOfQuarters = (int)Math.Ceiling((decimal)(remainingAmount / contractModel.RecurringPaymentAmount));

            // Calculate the total amount based on the initial payment and the recurring payments
            contractModel.TotalAmount = contractModel.InitialPayment + (numberOfQuarters * contractModel.RecurringPaymentAmount);

            // Calculate the total period in months
            contractModel.Period = numberOfQuarters * 3; // Total period in months
        }
    }
}