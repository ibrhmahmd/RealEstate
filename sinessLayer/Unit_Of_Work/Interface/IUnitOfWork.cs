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
        IRepositoryBase<UserDTO> UserRepository { get; }
        IRepositoryBase<PropertyDTO> PropertiesRepository {  get; }
        IRepositoryBase<ContractDTO> ContractsRepository { get; }
        IRepositoryBase<AddressDTO> AddressesRepository { get; }
        IRepositoryBase<PaymentDTO> PaymentsRepository { get; }
        Task SaveAsync();
    }
}
