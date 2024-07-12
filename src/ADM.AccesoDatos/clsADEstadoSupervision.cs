using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADEstadoSupervision
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarEstadoSupervisorOperacion()
        {
            return objEjeSp.EjecSP("GEN_ListarEstadoSupervisionOperacion_SP");
        }
    }
}
