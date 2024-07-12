using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace DEP.AccesoDatos
{
    public class clsADFsd
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarLimiteCoberFSD()
        {
            return objEjeSp.EjecSP("DEP_ListarLimiteCoberFSD_SP");
        }

        public DataTable ADListarMotivoExclusionFSD()
        {
            return this.objEjeSp.EjecSP("DEP_ListarMotivoExclusionFSD_SP");
        }

        public DataTable ADRegistrarClienteExcluidoFSD(int idCliExcl, int idCli, int idExclusionFSD, DateTime dFechaInicio, DateTime dFechaHasta, bool lVigente)
        {
            return this.objEjeSp.EjecSP("DEP_RegistrarClienteExcluidoFSD_SP", idCliExcl, idCli, idExclusionFSD, dFechaInicio, dFechaHasta, lVigente);
        }

        public DataTable ADListarClienteExcluidoFSD()
        {
            return this.objEjeSp.EjecSP("DEP_ListarClienteExcluidoFSD_SP");
        }
    }
}
