using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDistribuida.Entidades
{
    public class Instancia
    {
        public string Nombre { get; set; }
        public string BaseDatos { get; set; }
        public string Tabla { get; set; }

        public Instancia()
        {

        }

        public Instancia(string nombre)
        {
            Nombre = nombre;
        }
    }
}
