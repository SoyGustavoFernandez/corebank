using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.WCFLogistica.AccesoDatos
{
    public class clsADWCFAutenticacion
    {
        public DataTable obtenerAgencias(params object[] parametros)
        {
            return new clsGENEjeSP().EjecSP("GEN_ListAgenciasUsu_Sp", parametros);
        }

        public DataTable obtenerPerfiles(params object[] parametros)
        {
            return new clsGENEjeSP().EjecSP("GEN_LisPerUsu_sp", parametros);
        }

        public DataTable obtenerDatosUsuario(params object[] parametros)
        {
            return new clsGENEjeSP().EjecSP("LOG_RetornaDatosUsuario_SP", parametros);
        }
    }
}
