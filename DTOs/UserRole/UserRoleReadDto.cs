using Infera_WebApi.DTOs.Role;
using Infera_WebApi.DTOs.User;

namespace Infera_WebApi.DTOs.UserRole
{
    public class UserRoleReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserReadDto UserReadDto { get; set; }
        //public Models.User User { get; set; }
        public int RoleId { get; set; }
        public RoleReadDto RoleReadDto { get; set; }
        //public Models.Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
