using BDDistribuida.Datos;
using BDDistribuida.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDistribuida.Negocio
{
    public static class NegocioPublicacion
    {
        public static List<Publicacion> DevolverListaInstancias()
        {
            return DatosPublicacion.DevolverListaInstancias();
        }

        public static List<Publicacion> DevolverBD(string nombre)
        {
            return DatosPublicacion.DevolverBD(nombre);
        }

        public static List<Publicacion> DevolverTablas(string bd, string instancia)
        {
            return DatosPublicacion.DevolverTablas(bd, instancia);
        }

        public static List<Publicacion> DevolverColumnas(Publicacion instancia)
        {
            return DatosPublicacion.DevolverColumnas(instancia);
        }

        public static bool PublicarReplicaSinFiltro(Publicacion publicacion)
        {
            return DatosPublicacion.PublicarReplicaSinFiltro(publicacion);
        }


        public static void RealizarSuscripcion(Publicacion publicacion, List<Suscripcion> datosSuscripcion)
        {
             DatosPublicacion.RealizarSuscripcion(publicacion,datosSuscripcion);
        }

        public static List<Publicacion> DevolverListaInstanciasOracle()
        {
            return DatosPublicacion.DevolverListaInstanciasOracle();
        }
    }
}
