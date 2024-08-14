using AutoMapper;
using Clean.Application.Dtos.Auth;
using Clean.Application.Dtos.Roles;
using Clean.Application.Dtos.Users;
using Clean.Domain.Entities;

namespace Clean.Application.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserDto, User>().ReverseMap();
            CreateMap<EditUserDto, User>().ReverseMap();
            CreateMap<AddRoleDto,Role>().ReverseMap();
            CreateMap<EditRoleDto, Role>().ReverseMap();
            CreateMap<SignupDto, User>().ReverseMap();
        }
    }
}
