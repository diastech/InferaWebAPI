using AutoMapper;
using Infera_WebApi.DTOs.Role;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.Role;

namespace Infera_WebApi.Profiles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleReadDto>();
            CreateMap<RolePostRequest, Role>();
            CreateMap<Role, RoleUpdateRequest>();

        }
    }
}
