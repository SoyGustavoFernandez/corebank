using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.AccesoDatos
{
    public class clsADTipoConsejo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoConsejo()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoConsejo_SP");
        }

        public DataTable InsertarTipoConsejo(string cTipoConsejo, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarTipoConsejo_SP",cTipoConsejo, lVigente);
        }

        public DataTable ActualizarTipoConsejo(string cTipoConsejo, bool lVigente, int idTipoConsejo)
        {
            return objEjeSp.EjecSP("RCP_ActualizarTipoConsejo_SP", cTipoConsejo, lVigente, idTipoConsejo);
        }
    }
}
