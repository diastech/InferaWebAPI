using System.ComponentModel.DataAnnotations;
using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Permission
{
    public class PermissionPostRequest:BaseRequest
    {
        [Required]
        public String Method { get; set; }
        [Required]
        public String Route { get; set; }

        public String? Description { get; set; }
    }
}
