using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;

namespace BusinessLayer.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define mapping between User and UserDTO
            CreateMap<User, UserDTO>()
                    .ReverseMap();
            //CreateMap<UserDTO, User>();

            CreateMap<Property, PropertyDTO>()
                    .ReverseMap();


            CreateMap<Contract, ContractDTO>()
             .ReverseMap();

            CreateMap<Payment, PaymentDTO>()             
                .ReverseMap();

            CreateMap<AddressDTO, Address>()
             .ReverseMap();

            CreateMap<ProjectDTO, Project>()
            .ReverseMap();

            CreateMap<DeveloperCompanyDTO, DeveloperCompany>()
            .ReverseMap();


        }
    }

}