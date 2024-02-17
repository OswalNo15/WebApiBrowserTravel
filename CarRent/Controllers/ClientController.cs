using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IClientService _ClientService;


        public ClientController(IClientService ClientService)
        {
            this._ClientService = ClientService;
        }

        public ClientController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();

        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();

        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();

        }
    }
}
