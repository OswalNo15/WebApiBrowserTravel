using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.Models.Custom;
using ProyectoCrud.DAL.Services;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.DAL.Repositories;
using System.Diagnostics.Contracts;
using ProyectoCrud.Models;
namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProyectoCrud.DAL.Services.IAuthorizationService _authorizationService;

        private readonly IUserService _userService;

        public UserController(ProyectoCrud.DAL.Services.IAuthorizationService authorizationService, IUserService userService)
        {
            _authorizationService = authorizationService;
            this._userService = userService;
        }

        [HttpGet]
        [Route("ListUser")]
        public async Task<IActionResult> GetList() {

            try
            {

                IQueryable<User> queryContactoSQL = await _userService.GetAll();

                return Ok(queryContactoSQL);
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> PostAutenticarUser([FromBody] AuthorizationRequest authenticate) {
            var resultAuthenticate = await _authorizationService.ReturnToken(authenticate);

            if (resultAuthenticate == null) { return Unauthorized(); }
                
            return Ok(resultAuthenticate);
        }

        
    }
}
