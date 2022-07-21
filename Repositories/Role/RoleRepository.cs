using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.Role;
using Infera_WebApi.Requests.Role;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.Role
{
    public class RoleRepository: IRoleRepository
    {
        private readonly IMapper _mapper;
        private readonly SqlServerDbContext _context;

        public RoleRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<RoleReadDto> GetAll(RoleGetAllRequest roleGetAllRequest)
        {
            var roles = _context.Roles.AsQueryable();

            if(roleGetAllRequest.Name != null)
                roles = roles.Where(x => x.Name == roleGetAllRequest.Name);
            if(roleGetAllRequest.Description!= null)
                roles=roles.Where(x => x.Description == roleGetAllRequest.Description);
            
            foreach (string relation in roleGetAllRequest.Include)
            {
                if (relation == "User") roles = roles.Include(u => u.Users).ThenInclude(ur => ur.User);
            }

            roleGetAllRequest.TotalRecords=roles.Count();

            int Offset = (roleGetAllRequest.PageNumber - 1) * roleGetAllRequest.PageSize;
            int Limit = roleGetAllRequest.PageSize;

            var result = roles.OrderBy(u => u.Id)
                .Skip(Offset > 0 ? Offset : 0)
                .Take(Limit)
                .ToList();
            return _mapper.Map<IEnumerable<RoleReadDto>>(result);


        }

        public RoleReadDto GetById(int id)
        {
            return _mapper.Map<RoleReadDto>(_context.Roles.FirstOrDefault(u => u.Id == id));
        }

        public RoleReadDto Post(RolePostRequest rolePostRequest)
        {
            if (rolePostRequest == null)
                throw new ArgumentNullException(nameof(RoleUpdateRequest));
            Models.Role role = _mapper.Map<Models.Role>(rolePostRequest);
            _context.Roles.Add(role);
            SaveChanges();
            return _mapper.Map<RoleReadDto>(role);
        }

        public bool Update(int Id, RoleUpdateRequest roleUpdateRequest)
        {
            if(roleUpdateRequest == null)
                throw new ArgumentNullException(nameof(RoleUpdateRequest));
            if(Id==null)
                throw new ArgumentNullException(nameof(Id));

            Models.Role role= _context.Roles.FirstOrDefault(u => u.Id == Id);

            if (role == null)
                throw new KeyNotFoundException(nameof(Id));

            if(roleUpdateRequest.Name!=null) role.Name = roleUpdateRequest.Name;
            if (roleUpdateRequest.Description!=null) role.Description = roleUpdateRequest.Description;
            _context.Entry(role).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(role, roleUpdateRequest);
            return true;
        }

        public bool Delete(int Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            Models.Role role=_context.Roles.FirstOrDefault(u => u.Id == Id);
            if (role == null)
                throw new KeyNotFoundException(nameof(Id));
            _context.Roles.Remove(role);
            SaveChanges();
            return true;
        }

        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
