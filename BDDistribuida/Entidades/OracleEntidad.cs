using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDistribuida.Entidades
{
    public class OracleEntidad
    {
        public string user { get; set; }
        public string contrasena { get; set; }

        public OracleEntidad()
        {

        }

        public OracleEntidad(string user, string contrasena)
        {
            this.user = user;
            this.contrasena = contrasena;
        }
    }
}
