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
            IQueryable<Reservation> Reservations = await _ReservationService.GetAll();

            return Ok(Reservations);
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Reservation Reservations = await _ReservationService.Get(id);

            return Ok(Reservations);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation reservation)
        {
            bool Create = await _ReservationService.Insert(reservation);

            return Ok(new { create = Create, reservation });
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Reservation reservation)
        {
            bool update = await _ReservationService.Update(reservation);

            return Ok(new { update = update, reservation });
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Reservation reservation = await _ReservationService.Get(id);


            bool Deleted = await _ReservationService.Delete(id);


            return Ok(new { deleted =Deleted, reservation });
        }
    }
}
