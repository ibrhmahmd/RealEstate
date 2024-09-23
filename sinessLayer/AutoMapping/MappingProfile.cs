using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace ServicesLayer.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define mapping between User and UserDTO
            CreateMap<User, UserDTO>()
                .ReverseMap();


            CreateMap<Property, PropertyDTO>()
                .ReverseMap();


            CreateMap<Contract, ContractDTO>()
             .ReverseMap();


            CreateMap<Payment, PaymentDTO>()             
                .ReverseMap();


            CreateMap<AddressDTO, Address>()
             .ReverseMap();

        }
    }

}