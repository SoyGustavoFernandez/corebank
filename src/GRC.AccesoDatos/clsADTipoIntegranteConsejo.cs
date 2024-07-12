using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.AccesoDatos
{
    public class clsADTipoIntegranteConsejo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoIntegranteConsejo()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoIntegranteConsejo_SP");
        }

        public DataTable InsertarTipoIntegranteConsejo(int idTipoConsejo, string cTipoIntegranteConsejo, bool lDerechoVoto, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarTipoIntegranteConsejo_SP", idTipoConsejo,  cTipoIntegranteConsejo,  lDerechoVoto,  lVigente);
        }

        public DataTable ActualizarTipoIntegranteConsejo(int idTipoConsejo, string cTipoIntegranteConsejo, bool lDerechoVoto, bool lVigente, int idTipoIntegranteConsejo)
        {
            return objEjeSp.EjecSP("RCP_ActualizarTipoIntegranteConsejo_SP", idTipoConsejo, cTipoIntegranteConsejo, lDerechoVoto, lVigente, idTipoIntegranteConsejo);
        }
    }
}
