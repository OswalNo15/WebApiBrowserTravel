using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using ProyectoCrud.Models.Custom;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly IAuthorizationService _authorizationService;

        private readonly ICarService _carService;


        public CarController(ICarService userService, IAuthorizationService authorizationService)
        {
            this._carService = userService;
            _authorizationService = authorizationService;

        }


        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<Car> cars = await _carService.GetAll();

            return Ok(cars);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int year)
        {
            IQueryable<Car> car = await _carService.GetForModel(year);

            return Ok(car);
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car car)
        {
            bool insert = await _carService.Insert(car);

            return Ok(new { create = insert, car});
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Car car)
        {
            bool insert = await _carService.Update(car);

            return Ok(new { create = insert, car });
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _carService.Delete(id);

            return Ok(deleted);
        }

        
        [HttpGet]
        [Route("ListCarForLocalityCollected")]
        public async Task<IActionResult> GetForLocalityCollected(string LocalityCollected)
        {
            IQueryable<Car> car = await _carService.GetForLocalityCollected(LocalityCollected);

            return Ok(car);
        }
        
        [HttpGet]
        [Route("ListForReturnLocation")]
        public async Task<IActionResult> GetForReturnLocation(string ReturnLocation)
        {
            IQueryable<Car> car = await _carService.GetForLocalityCollected(ReturnLocation);

            return Ok(car);
        }
    }
}
