using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get all Projects
        public async Task<IQueryable<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _unitOfWork.ProjectsRepository.GetAllAsync(1,5);
            return _mapper.Map<IQueryable<ProjectDTO>>(projects);
        }

        // Get Project by ID
        public async Task<ProjectDTO> GetProjectByIdAsync(Guid id)
        {
            var project = await _unitOfWork.ProjectsRepository.GetByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }
            return _mapper.Map<ProjectDTO>(project);
        }

        // Create a new project
        public async Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _unitOfWork.ProjectsRepository.InsertAsync(project);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProjectDTO>(project);
        }

        // Update a project
        public async Task<ProjectDTO> UpdateProjectAsync(ProjectDTO projectDto)
        {
            var existingProject = await _unitOfWork.ProjectsRepository.GetByIdAsync(projectDto.Id);
            if (existingProject == null)
            {
                throw new KeyNotFoundException($"Project with ID {projectDto.Id} not found.");
            }
            var newproject =_mapper.Map<Project>(projectDto);
            await _unitOfWork.ProjectsRepository.UpdateAsync(newproject);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProjectDTO>(existingProject);
        }

        // Soft delete a project
        public async Task SoftDeleteProjectAsync(Guid id)
        {
            var project = await _unitOfWork.ProjectsRepository.GetByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }
            await _unitOfWork.ProjectsRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        // Restore a soft deleted project
        public async Task RestoreProjectAsync(Guid id)
        {
            var project = await _unitOfWork.ProjectsRepository.GetByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            if (!project.IsDeleted)
            {
                throw new InvalidOperationException($"Project with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.ProjectsRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}