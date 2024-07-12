using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADMotivoRechazoSolCreEval
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarMotivo(int nCondicion)
        {
            return objEjeSp.EjecSP("CRE_ListarMotivosRechazoSolCreEval_SP", nCondicion);
        }
    }
}
