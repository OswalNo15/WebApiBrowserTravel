using ProyectoCrud.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResponse> ReturnToken(AuthorizationRequest Authorization);
    }
}
