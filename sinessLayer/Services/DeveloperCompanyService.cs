﻿using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DeveloperCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeveloperCompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        // Get all Developer Companies
        public async Task<IQueryable<DeveloperCompanyDTO>> GetAllDeveloperCompaniesAsync()
        {
            var companies = await _unitOfWork.DeveloperCompaniesRepository.GetAllAsync();
            return _mapper.Map<IQueryable<DeveloperCompanyDTO>>(companies);
        }




        // Get Developer Company by ID
        public async Task<DeveloperCompanyDTO> GetDeveloperCompanyByIdAsync(Guid id)
        {
            var company = await _unitOfWork.DeveloperCompaniesRepository.GetByIdAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException($"Developer Company with ID {id} not found.");
            }
            return _mapper.Map<DeveloperCompanyDTO>(company);
        }


        // Create a new Developer Company
        public async Task<DeveloperCompanyDTO> CreateDeveloperCompanyAsync(DeveloperCompanyDTO companyDto)
        {
            var company = _mapper.Map<DeveloperCompany>(companyDto);
            await _unitOfWork.DeveloperCompaniesRepository.InsertAsync(company);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DeveloperCompanyDTO>(company);
        }

        // Update a Developer Company
        public async Task<DeveloperCompanyDTO> UpdateDeveloperCompanyAsync(DeveloperCompanyDTO companyDto)
        {
            var existingCompany = await _unitOfWork.DeveloperCompaniesRepository.GetByIdAsync(companyDto.Id);
            if (existingCompany == null)
            {
                throw new KeyNotFoundException($"Developer Company with ID {companyDto.Id} not found.");
            }
            _mapper.Map(companyDto, existingCompany);
            await _unitOfWork.DeveloperCompaniesRepository.UpdateAsync(existingCompany);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DeveloperCompanyDTO>(existingCompany);
        }


        // Soft delete a Developer Company
        public async Task SoftDeleteDeveloperCompanyAsync(Guid id)
        {
            var company = await _unitOfWork.DeveloperCompaniesRepository.GetByIdAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException($"Developer Company with ID {id} not found.");
            }
            await _unitOfWork.DeveloperCompaniesRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        // Restore a soft deleted Developer Company
        public async Task RestoreDeveloperCompanyAsync(Guid id)
        {
            var company = await _unitOfWork.DeveloperCompaniesRepository.GetByIdAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException($"Developer Company with ID {id} not found.");
            }

            if (!company.IsDeleted)
            {
                throw new InvalidOperationException($"Developer Company with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.DeveloperCompaniesRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}