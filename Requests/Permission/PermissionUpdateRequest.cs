using Infera_WebApi.Requests.Base;

namespace Infera_WebApi.Requests.Permission
{
    public class PermissionUpdateRequest:BaseRequest
    {
        public String? Method { get; set; }
        public String? Route { get; set; }
        public String? Description { get; set; }
    }
}
