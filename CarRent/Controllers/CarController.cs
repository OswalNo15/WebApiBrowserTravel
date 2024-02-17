using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models.Custom;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly IAuthorizationService _authorizationService;

        private readonly ICarService _carService;


        public CarController(ICarService userService)
        {
            this._carService = userService;
        }

        public CarController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();    
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorizationRequest authenticate)
        {
            //var resultAuthenticate = await _authorizationService.ReturnToken(authenticate);

            //if (resultAuthenticate == null) { return Unauthorized(); }


            //return Ok(resultAuthenticate);
            return Ok();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorizationRequest authenticate)
        {
            return Ok();

        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();

        }
    }
}
