using System.ComponentModel.DataAnnotations;
using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Role
{
    public class RolePostRequest:BaseRequest
    {
        [Required]
        public String Name { get; set; }
        public String? Description { get; set; }
    }
}
