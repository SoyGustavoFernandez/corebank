using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.AccesoDatos
{
    public class clsADTipoSesion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoSesion()
        {
            return objEjeSp.EjecSP("RCP_ListarTipoSesion_SP");
        }

        public DataTable InsertarTipoSesion(string cTipoSesion, bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarTipoSesion_SP", cTipoSesion, lVigente);
        }

        public DataTable ActualizarTipoSesion(string cTipoSesion, bool lVigente, int idTipoSesion)
        {
            return objEjeSp.EjecSP("RCP_ActualizarTipoSesion_SP", cTipoSesion, lVigente, idTipoSesion);
        }
    }
}
