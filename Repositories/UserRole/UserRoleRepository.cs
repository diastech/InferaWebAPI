using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Requests.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.UserRole
{
    public class UserRoleRepository:IUserRoleRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<UserRoleReadDto> GetAll(UserRoleGetAllRequest userRoleGetAllRequest)
        {
            var userRoles = _context.UserRoles.AsQueryable();

            if (userRoleGetAllRequest.UserId != null)
                userRoles = userRoles.Where(x => x.UserId == userRoleGetAllRequest.UserId);
            if (userRoleGetAllRequest.RoleId != null)
                userRoles = userRoles.Where(x => x.RoleId == userRoleGetAllRequest.RoleId);

            foreach (string relation in userRoleGetAllRequest.Include)
            {
                if (relation == "User") userRoles = userRoles.Include(ur => ur.User);
                if (relation == "Role") userRoles = userRoles.Include(ur => ur.Role);
            }

            userRoleGetAllRequest.TotalRecords=userRoles.Count();

            
            int Offset = (userRoleGetAllRequest.PageNumber - 1) * userRoleGetAllRequest.PageSize;
            int Limit = userRoleGetAllRequest.PageSize;

            var result = userRoles.OrderBy(ur => ur.Id).Skip(Offset > 0 ? Offset : 0).Take(Limit).ToList();

            return _mapper.Map<IEnumerable<UserRoleReadDto>>(result);
        }

        public UserRoleReadDto GetById(int id)
        {
            var userRole = _context.UserRoles.Include(ur => ur.User)
                .Include(ur => ur.Role)
                .FirstOrDefault(ur => ur.Id == id);
            return _mapper.Map<UserRoleReadDto>(userRole);
        }

        public UserRoleReadDto Post(UserRolePostRequest userRolePostRequest)
        {
            if(userRolePostRequest == null)
                throw new ArgumentNullException(nameof(userRolePostRequest));
            Models.UserRole userRole = _mapper.Map<Models.UserRole>(userRolePostRequest);
            _context.UserRoles.Add(userRole);
            SaveChanges();
            return _mapper.Map<UserRoleReadDto>(userRole);

        }

        public bool Update(int Id, UserRoleUpdateRequest userRoleUpdateRequest)
        {
            if(userRoleUpdateRequest==null)
                throw new ArgumentNullException(nameof(userRoleUpdateRequest));
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            Models.UserRole userRole=_context.UserRoles.FirstOrDefault(ur => ur.Id == Id);

            if (userRole == null)
                throw new KeyNotFoundException(nameof(Id));

            if (userRoleUpdateRequest.UserId != null) userRole.UserId = (int)userRoleUpdateRequest.UserId;
            if (userRoleUpdateRequest.RoleId != null) userRole.RoleId = (int)userRoleUpdateRequest.RoleId;

            _context.Entry(userRole).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(userRole, userRoleUpdateRequest);
            return true;
        }

        public bool Delete(int Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            Models.UserRole userRole = _context.UserRoles.FirstOrDefault(ur => ur.Id == Id);
            if (userRole == null)
                throw new KeyNotFoundException(nameof(Id));
            _context.UserRoles.Remove(userRole);
            SaveChanges();
            return true;
        }

        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
