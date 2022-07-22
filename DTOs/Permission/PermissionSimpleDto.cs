namespace Infera_WebApi.DTOs.Permission
{
    public class PermissionSimpleDto
    {
        public int Id { get; set; }
        public String Method { get; set; }
        public String Route { get; set; }
        public String Description { get; set; }
    }
}
