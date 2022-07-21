using AutoMapper;
using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.UserRole;

namespace Infera_WebApi.Profiles
{
    public class UserRoleProfile:Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleReadDto>()
                .ForMember(urr => urr.RoleReadDto, opt => opt.MapFrom(ur => ur.Role))
                .ForMember(urr => urr.UserReadDto, opt => opt.MapFrom(ur => ur.User));
            CreateMap<UserRolePostRequest, UserRole>();
            CreateMap<UserRole, UserRoleUpdateRequest>();
        }
    }
}
