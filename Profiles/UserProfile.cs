using AutoMapper;
using Infera_WebApi.DTOs.User;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.User;

namespace Infera_WebApi.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserReadDto>()
                .ForMember(ur => ur.Roles, opt => opt.MapFrom(u => u.Roles));
            CreateMap<UserReadDto, User>();
            CreateMap<UserPostRequest,User>();
            CreateMap<User, UserPostRequest>();
            CreateMap<User, UserUpdateRequest>();
            CreateMap<User, UserForUserRoleDto>()
                .ForMember(ufur => ufur.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(ufur => ufur.Name, opt => opt.MapFrom(u => u.Name))
                .ForMember(ufur => ufur.Surname, opt => opt.MapFrom(u => u.Surname))
                .ForMember(ufur => ufur.Email, opt => opt.MapFrom(u => u.Email));
        }
    }
}
