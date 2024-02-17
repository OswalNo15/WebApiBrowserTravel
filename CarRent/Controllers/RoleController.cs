using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using System.Data;

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
            IQueryable<Role> roles = await _RoleService.GetAll();

            return Ok(roles);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string roleNme)
        {
            Role roles = await _RoleService.GetForRole(roleNme);

            return Ok(roles);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            bool Create = await _RoleService.Insert(role);

            return Ok( new { create = Create, role });
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Role role)
        {
            bool update = await _RoleService.Update(role);

            return Ok(new {update = update , role});
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _RoleService.Delete(id);


            return Ok(deleted);
        }
    }
}
