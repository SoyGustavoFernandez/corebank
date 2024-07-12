using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADActividadInternaConfig
    {
        IntConexion objEjeSp;

        public clsADActividadInternaConfig()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ADRecuperarSectorEconomico(string cSectorEcon = "")
        {
            return objEjeSp.EjecSP("CRE_RecuperarSectorEconomico_SP", cSectorEcon);
        }

        public DataTable ADRecuperarListaConfigActividadInterna()
        {
            return objEjeSp.EjecSP("CRE_RecuperarListaConfigActividadInterna_SP");
        }

        public DataTable ADRegActualizarActividadEconomicaConfig(string xmlActividadEconConfig, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_RegActualizarActividadEconomicaConfig_SP", xmlActividadEconConfig, idUsuario);
        }
    }
}
