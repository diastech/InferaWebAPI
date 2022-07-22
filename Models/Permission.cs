using Infera_WebApi.Models.Base;

namespace Infera_WebApi.Models
{
    public class Permission:BaseModel
    {
        public String Method { get; set; }
        public String Route { get; set; }
        public String? Controller { get; set; }
        public String? Description { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
