using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.BLL.Service;
using System.ComponentModel.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {

        private readonly IAuthorizationService _authorizationService;

        private readonly IPreferenceService _PreferenceService;


        public PreferenceController(IReferenceService PreferenceService)
        {
            this._PreferenceService = PreferenceService;
        }

        public PreferenceController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: api/<PreferenceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PreferenceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PreferenceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PreferenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PreferenceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
