using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceClientController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IClientService _PreferenceClientServiceService;


        public PreferenceClientController(IClientService PreferenceClientService, IAuthorizationService authorizationService)
        {
            this._PreferenceClientServiceService = PreferenceClientService;
            _authorizationService = authorizationService;

        }


        // GET: api/<PreferenceClientController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<PreferenceClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<PreferenceClientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<PreferenceClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<PreferenceClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();

        }
    }
}
