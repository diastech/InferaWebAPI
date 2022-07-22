using Infera_WebApi.DTOs.Permission;
using Infera_WebApi.Requests.Permission;

namespace Infera_WebApi.Repositories.Permission
{
    public interface IPermissionRepository
    {
        public IEnumerable<PermissionReadDto> GetAll(PermissionGetAllRequest permissionGetAllRequest);
        public PermissionReadDto GetById(int id);
        public PermissionReadDto Post(PermissionPostRequest permissionPostRequest);
        public Boolean Update(int id, PermissionUpdateRequest permissionUpdateRequest);
        public Boolean Delete(int id);
    }
}
