using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.Models.Custom;
using ProyectoCrud.DAL.Services;
namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProyectoCrud.DAL.Services.IAuthorizationService _authorizationService;

        public UserController(ProyectoCrud.DAL.Services.IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [Authorize]
        [HttpGet]
        [Route("ListUser")]
        public async Task<IActionResult> GetList() {
            var ListaUsuario = await Task.FromResult(new List<string> {

        "Carlos",
        "Lo mama",
        "Kuxan",
        "Sinomino",
        "Explotacion laboral"
        });


            return Ok(ListaUsuario);
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> PostAutenticarUser([FromBody] AuthorizationRequest authenticate) {
            var resultAuthenticate = await _authorizationService.ReturnToken(authenticate);

            if (resultAuthenticate == null)
                return Unauthorized();

            return Ok(resultAuthenticate);


        }

        
    }
}
