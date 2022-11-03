using BDDistribuida.Datos;
using BDDistribuida.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDistribuida.Negocio
{
    public static class NegocioInstancias
    {
        public static List<Instancia> DevolverListaInstancias()
        {
            return DatosInstancia.DevolverListaInstancias();
        }

        public static List<Instancia> DevolverBD(string nombre)
        {
            return DatosInstancia.DevolverBD(nombre);
        }

        public static List<Instancia> DevolverTablas(string bd, string instancia)
        {
            return DatosInstancia.DevolverTablas(bd, instancia);
        }

        public static List<Instancia> DevolverColumnas(Instancia instancia)
        {
            return DatosInstancia.DevolverColumnas(instancia);
        }
    }
}
