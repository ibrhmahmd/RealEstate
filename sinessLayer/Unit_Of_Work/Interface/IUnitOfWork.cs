using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using DataAccessLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepositoryBase<User> UserRepository { get; }
        IRepositoryBase<Property> PropertiesRepository { get; }
        IRepositoryBase<Contract> ContractsRepository { get; }
        IRepositoryBase<Address> AddressesRepository { get; }
        IRepositoryBase<Payment> PaymentsRepository { get; }
        IRepositoryBase<Project> ProjectsRepository { get; }
        IRepositoryBase<DeveloperCompany> DeveloperCompaniesRepository { get; }
        Task SaveAsync();
    }
}
