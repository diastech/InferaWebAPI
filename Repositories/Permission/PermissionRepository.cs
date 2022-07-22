using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.Permission;
using Infera_WebApi.Requests.Permission;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.Permission
{
    public class PermissionRepository:IPermissionRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEnumerable<EndpointDataSource> _endpointDataSources;

        public PermissionRepository(SqlServerDbContext context, IMapper mapper, IEnumerable<EndpointDataSource> endpointDataSources)
        {
            _context = context;
            _mapper = mapper;
            _endpointDataSources = endpointDataSources;
        }
        public IEnumerable<PermissionReadDto> GetAll(PermissionGetAllRequest permissionGetAllRequest)
        {
            var permissions = _context.Permissions.AsQueryable();

            if (permissionGetAllRequest.Route != null)
                permissions = permissions.Where(p => p.Route.Contains(permissionGetAllRequest.Route));
            if(permissionGetAllRequest.Method!=null)
                permissions = permissions.Where(p => p.Method.Contains(permissionGetAllRequest.Method));
            if (permissionGetAllRequest.Description != null)
                permissions = permissions.Where(p => p.Description.Contains(permissionGetAllRequest.Description));
            foreach (string relation in permissionGetAllRequest.Include)
            {
                if (relation == "User") permissions = permissions.Include(p => p.Users);
                if (relation == "Role") permissions = permissions.Include(p => p.Roles);
            }

            permissionGetAllRequest.TotalRecords=permissions.Count();
            var result= permissions.OrderBy(p=>p.Id)
                .Skip(permissionGetAllRequest.GetOffset())
                .Take(permissionGetAllRequest.GetLimit())
                .ToList();
            return _mapper.Map<IEnumerable<PermissionReadDto>>(result);
        }

        public PermissionReadDto GetById(int id)
        {
            return _mapper.Map<PermissionReadDto>(_context.Permissions.FirstOrDefault(p => p.Id == id));
        }

        public PermissionReadDto Post(PermissionPostRequest permissionPostRequest)
        {
            if(permissionPostRequest==null)
                throw new ArgumentNullException(nameof(permissionPostRequest));

            Models.Permission permission = _mapper.Map<Models.Permission>(permissionPostRequest);
            _context.Permissions.Add(permission);
            SaveChanges();
            return _mapper.Map<PermissionReadDto>(permission);

        }

        public bool Update(int id, PermissionUpdateRequest permissionUpdateRequest)
        {
            if (permissionUpdateRequest == null)
                throw new ArgumentNullException(nameof(permissionUpdateRequest));

            Models.Permission permission=_context.Permissions.FirstOrDefault(p => p.Id == id);
            
            if (permission == null)
                throw new KeyNotFoundException(nameof(id));

            if (permissionUpdateRequest.Route != null) permission.Route = permissionUpdateRequest.Route;
            if (permissionUpdateRequest.Method != null) permission.Method = permissionUpdateRequest.Method;
            if (permissionUpdateRequest.Description != null)
                permission.Description = permissionUpdateRequest.Description;

            _context.Entry(permission).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Models.Permission permission=_context.Permissions.FirstOrDefault(p => p.Id == id);
            if(permission==null)
                throw new KeyNotFoundException(nameof(id));
            _context.Permissions.Remove(permission);
            SaveChanges();
            return true;
        }

        public void AutoMapEndpoints()
        {
            var endpoints = _endpointDataSources.SelectMany(es => es.Endpoints).OfType<RouteEndpoint>();
            endpoints.Select(e =>
            {
                Models.Permission newPermission=new Models.Permission();
                var controller = e.Metadata.OfType<ControllerActionDescriptor>().FirstOrDefault();
                var action = controller != null ? $"{controller.ControllerName}.{controller.ActionName}" : null;
                var controllerMetod = controller != null
                    ? $"{controller.ControllerTypeInfo.FullName}.{controller.MethodInfo.Name}"
                    : null;
                newPermission.Method = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods?[0];
                newPermission.Route = $"/{e.RoutePattern.RawText.TrimStart('/')}";
                newPermission.Controller = controllerMetod;
                AddIfNotExists(newPermission);
                return 0;
            });
        }

        private void AddIfNotExists(Models.Permission permission)
        {
            Models.Permission existPermission=_context.Permissions.FirstOrDefault(p => p.Id == permission.Id);
            if (existPermission == null)
                _context.Permissions.Add(permission);
        }

        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
