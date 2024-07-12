using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADNivelAprobPartidaPres
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaTodoNivelAprobPartida()
        {
            return objEjeSp.EjecSP("GEN_ListaNivelAprobacionPartida_SP", 0);
        }
    }
}
