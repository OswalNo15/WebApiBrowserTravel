using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdTypeController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IIdTypeService _IdTypeService;


        public IdTypeController(IIdTypeService IdTypeService)
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
            IQueryable<IdType> IdTypes = await _IdTypeService.GetAll();

            return Ok(IdTypes);
        }

        // GET api/<IdTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IdType IdType = await _IdTypeService.Get(id);

            return Ok(IdType);
        }

        // POST api/<IdTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IdType IdType)
        {
            bool insert = await _IdTypeService.Insert(IdType);

            return Ok(new { create = insert, IdType });
        }

        // PUT api/<IdTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] IdType IdType)
        {
            bool insert = await _IdTypeService.Update(IdType);

            return Ok(new { create = insert, IdType });
        }

        // DELETE api/<IdTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _IdTypeService.Delete(id);

            return Ok(deleted);
        }
    }
}
