using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADEstados
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable getEstadosAprobacion(int tipoOperacion)
        {
            return objEjeSp.EjecSP("RCP_ListarEstadosAprobacion_SP", tipoOperacion);
        }
    }
}
