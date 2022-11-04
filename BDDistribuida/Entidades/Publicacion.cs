using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDistribuida.Entidades
{
    public class Publicacion
    {
        public string NombreInstancia { get; set; }
        public string BaseDatos { get; set; }
        public string Tabla { get; set; }
        public string Filtro { get; set; }
        public string NombrePub { get; set; }
        public string Contraseña { get; set; }
        public Publicacion()
        {

        }

        public Publicacion(string nombre)
        {
            NombreInstancia = nombre;
        }
    }
}
