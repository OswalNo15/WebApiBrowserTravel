using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.Models.Custom
{
    public class AuthorizationResponse
    {
        public string Token { get; set; }= null!;
        public bool result { get; set; }
        public string message { get; set; } = null!;

    }
}
