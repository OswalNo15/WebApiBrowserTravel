using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.Models.Custom
{
    public class AuthorizationRequest
    {
        public string NameUser { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
