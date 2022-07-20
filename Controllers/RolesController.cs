using Infera_WebApi.DTOs.Role;
using Infera_WebApi.DTOs.User;
using Infera_WebApi.Repositories.Role;
using Infera_WebApi.Requests.Role;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infera_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public PagedResponse<RoleReadDto> Get([FromBody] RoleGetAllRequest roleGetAllRequest)
        {
            IEnumerable<RoleReadDto> data = _roleRepository.GetAll(roleGetAllRequest);
            return new PagedResponse<RoleReadDto>(data.ToList(), roleGetAllRequest.PageNumber,
                roleGetAllRequest.PageSize, roleGetAllRequest.TotalRecords);
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public RoleReadDto Get(int id)
        {
            return _roleRepository.GetById(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public RoleReadDto Post([FromBody] RolePostRequest rolePostRequest)
        {
            return _roleRepository.Post(rolePostRequest);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleUpdateRequest roleUpdateRequest)
        {
            if (_roleRepository.Update(id,roleUpdateRequest))
                return Ok();

            return NotFound();
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_roleRepository.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
