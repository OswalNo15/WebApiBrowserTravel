using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IAuthorizationService _authorizationService;

        private readonly IReservationService _ReservationService;


        public ReservationController(IReservationService ReservationService)
        {
            this._ReservationService = ReservationService;
        }

        public ReservationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();

        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();

        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();

        }
    }
}
