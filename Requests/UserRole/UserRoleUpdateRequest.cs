using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.UserRole
{
    public class UserRoleUpdateRequest:BaseRequest
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}
