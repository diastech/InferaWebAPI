using Infera_WebApi.DTOs.Permission;
using Infera_WebApi.Repositories.Permission;
using Infera_WebApi.Requests.Permission;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infera_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionsController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        // GET: api/<PermissionsController>
        [HttpGet]
        public PagedResponse<PermissionReadDto> Get(PermissionGetAllRequest permissionGetAllRequest)
        {
            IEnumerable<PermissionReadDto> data = _permissionRepository.GetAll(permissionGetAllRequest);
            return new PagedResponse<PermissionReadDto>(data.ToList(), permissionGetAllRequest.PageNumber,
                permissionGetAllRequest.PageSize, permissionGetAllRequest.TotalRecords);
        }

        // GET api/<PermissionsController>/5
        [HttpGet("{id}")]
        public PermissionReadDto Get(int id)
        {
            return _permissionRepository.GetById(id);
        }

        // POST api/<PermissionsController>
        [HttpPost]
        public PermissionReadDto Post([FromBody] PermissionPostRequest permissionPostRequest)
        {
            return _permissionRepository.Post(permissionPostRequest);
        }

        // PUT api/<PermissionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PermissionUpdateRequest permissionUpdateRequest)
        {
            if (_permissionRepository.Update(id, permissionUpdateRequest))
                return Ok();
            return NotFound();
        }

        // DELETE api/<PermissionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_permissionRepository.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
