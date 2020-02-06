using AutoMapper;
using EmployeeManagement.Core.Dtos;

namespace EmployeeManagement.API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}