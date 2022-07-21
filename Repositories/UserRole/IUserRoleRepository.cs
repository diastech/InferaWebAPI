using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Requests.UserRole;

namespace Infera_WebApi.Repositories.UserRole
{
    public interface IUserRoleRepository
    {
        public IEnumerable<UserRoleReadDto> GetAll(UserRoleGetAllRequest userRoleGetAllRequest);
        public UserRoleReadDto GetById(int id);
        public UserRoleReadDto Post(UserRolePostRequest userRolePostRequest);
        public bool Update(int Id, UserRoleUpdateRequest userRoleUpdateRequest);
        public bool Delete(int Id);
    }
}
