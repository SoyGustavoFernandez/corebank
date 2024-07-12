using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoEvaluacion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoEvaluacion()
        {
            return objEjeSp.EjecSP("CRE_ObtenerTipoEvaluacion_SP");
        }
    }
}
