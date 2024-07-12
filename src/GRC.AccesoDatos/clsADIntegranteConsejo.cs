using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.AccesoDatos
{
    public class clsADIntegranteConsejo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarIntegranteConsejo()
        {
            return objEjeSp.EjecSP("RCP_ListarIntegranteConsejo_SP");
        }

        public DataTable ListarIntegranteIdConsejo(int idConsejo)
        {
            return objEjeSp.EjecSP("RCP_ListarIntegranteIdConsejo_SP", idConsejo);
        }

        public DataTable ListarIntegranteConsejoidCli(int idCli)
        {
            return objEjeSp.EjecSP("RCP_ListarIntegranteConsejoidCli_SP", idCli);
        }

        public DataTable InsertarIntegranteConsejo(int idConsejo, int idCli, DateTime dFecIni, DateTime dFecfin, int idTipoIntegranteConsejo, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarIntegranteConsejo_SP", idConsejo,idCli,  dFecIni,  dFecfin,  idTipoIntegranteConsejo,  lVigente);
        }

        public DataTable ActualizarIntegranteConsejo(int idConsejo, int idCli, DateTime dFecIni, DateTime dFecfin, int idTipoIntegranteConsejo, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_ActualizarIntegranteConsejo_SP", idConsejo, idCli, dFecIni, dFecfin, idTipoIntegranteConsejo, lVigente);
        }
    }
}
