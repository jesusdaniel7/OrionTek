using AutoMapper;
using OrionTek.Contracts.Models;
using OrionTek.Entities.Dtos.Creational;

namespace OrionTek.API.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<AddressDTO, Address>();
        }
    }
}
