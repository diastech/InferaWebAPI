using System.ComponentModel.DataAnnotations;
using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.UserRole
{
    public class UserRolePostRequest:BaseRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
