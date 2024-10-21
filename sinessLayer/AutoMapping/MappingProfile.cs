using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;

namespace BusinessLayer.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define mapping between User and UserDTO
            CreateMap<User, UserDTO>()
                    .ReverseMap();

            CreateMap<Property, PropertyDTO>();
            CreateMap<PropertyDTO, Property>();
            CreateMap<PropertyDTO, Property>()
         .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()); // Ignore CreatedOn
            CreateMap<Property, PropertyDTO>();

            CreateMap<Contract, ContractDTO>()
             .ReverseMap();
            CreateMap<Contract, ContractDTO>()
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore());

            CreateMap<Payment, PaymentDTO>()             
                .ReverseMap();

            CreateMap<AddressDTO, Address>()
             .ReverseMap();

            CreateMap<ProjectDTO, Project>()
            .ReverseMap();

            CreateMap<DeveloperCompanyDTO, DeveloperCompany>()
            .ReverseMap();


            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));


        }
    }

}