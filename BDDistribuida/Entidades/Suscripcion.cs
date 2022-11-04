using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDistribuida.Entidades
{
    public class Suscripcion
    {
        public string NombreIntanciaS { get; set; }
        public string NombreBDS { get; set; }

        public Suscripcion()
        {
        }

        public Suscripcion(string nombreIntanciaS, string nombreBDS)
        {
            NombreIntanciaS = nombreIntanciaS;
            NombreBDS = nombreBDS;
        }
    }
}
