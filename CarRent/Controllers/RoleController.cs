using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IRoleService _RoleService;


        public RoleController(IRoleService RoleService)
        {
            this._RoleService = RoleService;
        }

        public RoleController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
