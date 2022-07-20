using System.ComponentModel.DataAnnotations;

namespace Infera_WebApi.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
    }
}
