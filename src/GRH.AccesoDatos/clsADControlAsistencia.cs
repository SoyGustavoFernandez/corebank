using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADControlAsistencia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADMarcarAsistenciaPC(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_MarcarAsistenciaPC_SP", idUsuario);
        }
    }
}
