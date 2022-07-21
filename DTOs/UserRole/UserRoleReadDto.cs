using Infera_WebApi.DTOs.Role;
using Infera_WebApi.DTOs.User;

namespace Infera_WebApi.DTOs.UserRole
{
    public class UserRoleReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserForUserRoleDto User { get; set; }
        public int RoleId { get; set; }
        public RoleForUserRoleDto Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
