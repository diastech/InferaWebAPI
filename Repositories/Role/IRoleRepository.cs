using Infera_WebApi.DTOs.Role;
using Infera_WebApi.Requests.Role;

namespace Infera_WebApi.Repositories.Role
{
    public interface IRoleRepository
    {
        public IEnumerable<RoleReadDto> GetAll(RoleGetAllRequest roleGetAllRequest);
        public RoleReadDto GetById(int id);
        public RoleReadDto Post(RolePostRequest rolePostRequest);
        public bool Update(int Id, RoleUpdateRequest roleUpdateRequest);
        public bool Delete(int Id);
    }
}
