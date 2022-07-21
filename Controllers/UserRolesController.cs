using Infera_WebApi.DTOs.UserRole;
using Infera_WebApi.Repositories.UserRole;
using Infera_WebApi.Requests.UserRole;
using Infera_WebApi.Responses.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infera_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRolesController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        // GET: api/<UserRolesController>
        [HttpGet]
        public PagedResponse<UserRoleReadDto> Get([FromBody] UserRoleGetAllRequest userRoleGetAllRequest)
        {
            IEnumerable<UserRoleReadDto> data = _userRoleRepository.GetAll(userRoleGetAllRequest);
            return new PagedResponse<UserRoleReadDto>(data.ToList(), userRoleGetAllRequest.PageNumber,
                userRoleGetAllRequest.PageSize, userRoleGetAllRequest.TotalRecords);
        }

        // GET api/<UserRolesController>/5
        [HttpGet("{id}")]
        public UserRoleReadDto Get(int id)
        {
            return _userRoleRepository.GetById(id);
        }

        // POST api/<UserRolesController>
        [HttpPost]
        public UserRoleReadDto Post([FromBody] UserRolePostRequest userRolePostRequest)
        {
            return _userRoleRepository.Post(userRolePostRequest);
        }

        // PUT api/<UserRolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserRoleUpdateRequest userRoleUpdateRequest)
        {
            if (_userRoleRepository.Update(id, userRoleUpdateRequest))
                return Ok();
            return NotFound();
        }

        // DELETE api/<UserRolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_userRoleRepository.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
