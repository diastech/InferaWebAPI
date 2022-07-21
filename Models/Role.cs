using Infera_WebApi.Models.Base;

namespace Infera_WebApi.Models
{
    public class Role:BaseModel
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
