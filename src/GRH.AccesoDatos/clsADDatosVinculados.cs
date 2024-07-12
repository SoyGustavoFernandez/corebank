using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADDatosVinculados
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable getDatosVinculados(int estado)
        {
            return objEjeSp.EjecSP("GRH_DatosVinculados_SP",estado);
        }
    }
}
