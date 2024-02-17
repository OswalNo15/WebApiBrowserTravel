using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IClientService _ClientService;


        public ClientController(IClientService ClientService, IAuthorizationService authorizationService)
        {
            this._ClientService = ClientService;
            _authorizationService = authorizationService;

        }


        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<Client> clients = await _ClientService.GetAll();

            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Client client = await _ClientService.Get(id);

            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            bool insert = await _ClientService.Insert(client);

            return Ok(new { create = insert, client });
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Client client)
        {
            bool insert = await _ClientService.Update(client);

            return Ok(new { create = insert, client });
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _ClientService.Delete(id);

            return Ok(deleted);
        }
    }
}
