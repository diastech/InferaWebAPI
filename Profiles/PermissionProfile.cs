using AutoMapper;
using Infera_WebApi.DTOs.Permission;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.Permission;

namespace Infera_WebApi.Profiles
{
    public class PermissionProfile:Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionReadDto>();
            CreateMap<Permission, PermissionSimpleDto>();
            CreateMap<PermissionPostRequest, Permission>();
        }
    }
}
