using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNActividadInternaConfig
    {
        private clsADActividadInternaConfig objADActIntConfig { get; set; }

        public clsCNActividadInternaConfig()
        {
            objADActIntConfig = new clsADActividadInternaConfig();
        }
        public DataTable CNRecuperarSectorEconomico(string cSectorEcon = "")
        {
            return this.objADActIntConfig.ADRecuperarSectorEconomico(cSectorEcon);
        }

        public DataTable CNRecuperarListaConfigActividadInterna()
        {
            return this.objADActIntConfig.ADRecuperarListaConfigActividadInterna();
        }

        public DataTable CNRegActualizarActividadEconomicaConfig(string xmlActividadEconConfig, int idUsuario)
        {
            return this.objADActIntConfig.ADRegActualizarActividadEconomicaConfig(xmlActividadEconConfig, idUsuario);
        }
    }

}
