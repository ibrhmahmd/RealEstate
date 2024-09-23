using BusinessLayer.DTOModels;
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

        IRepository<UserDTO> Users{ get; }
        IRepository<PropertyDTO> Properties {  get; }
        IRepository<ContractDTO> Contracts { get; }
        IRepository<AddressDTO> Addresses { get; }
        IRepository<PaymentDTO> Payments{ get; }
        Task SaveAsync();
    }
}
