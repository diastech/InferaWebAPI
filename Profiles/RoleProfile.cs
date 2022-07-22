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
            CreateMap<Role, RoleReadDto>()
                .ForMember(rr => rr.Users, opt => opt.MapFrom(r => r.Users));
            CreateMap<RolePostRequest, Role>();
            CreateMap<Role, RoleUpdateRequest>();
            CreateMap<Role, RoleForUserRoleDto>()
                .ForMember(rfur => rfur.Id, opt => opt.MapFrom(r => r.Id))
                .ForMember(rfur => rfur.Name, opt => opt.MapFrom(r => r.Name))
                .ForMember(rfur => rfur.Description, opt => opt.MapFrom(r => r.Description));
            CreateMap<Role, RoleSimpleDto>();

        }
    }
}
