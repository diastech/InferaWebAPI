using Infera_WebApi.DTOs.Role;
using Infera_WebApi.DTOs.User;

namespace Infera_WebApi.DTOs.Permission
{
    public class PermissionReadDto
    {
        public int Id { get; set; }
        public String Method { get; set; }
        public String Route { get; set; }
        public String Description { get; set; }
        public String CreatedAt { get; set; }

        public ICollection<RoleSimpleDto> Roles { get; set; }
        public ICollection<UserSimpleDto> Users { get; set; }
    }
}
