using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.AccesoDatos
{
    public class clsADConsejo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarConsejo()
        {
            return objEjeSp.EjecSP("RCP_ListarConsejo_SP");
        }

        public DataTable ListarConsejoidConsejo(int idConsejo)
        {
            return objEjeSp.EjecSP("RCP_ListarConsejoidConsejo_SP", idConsejo);
        }

        public DataTable InsertarConsejo(string cConsejo, int idTipoConsejo, bool lVigente, string xmlIntegrante)
        {
            return objEjeSp.EjecSP("RCP_InsertarConsejo_SP", cConsejo, idTipoConsejo, lVigente, xmlIntegrante);
        }

        public DataTable ActualizarConsejo(string cConsejo, int idTipoConsejo, bool lVigente, int idConsejo, string xmlIntegrante)
        {
            return objEjeSp.EjecSP("RCP_ActualizarConsejo_SP", cConsejo, idTipoConsejo, lVigente, idConsejo, xmlIntegrante);
        }
    }
}
