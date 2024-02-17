using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdTypeController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IClientService _IdTypeService;


        public IdTypeController(IClientService IdTypeService)
        {
            this._IdTypeService = IdTypeService;
        }

        public IdTypeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: api/<IdTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<IdTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<IdTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<IdTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();

        }

        // DELETE api/<IdTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();

        }
    }
}
