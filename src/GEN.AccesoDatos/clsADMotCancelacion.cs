using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADMotCancelacion
    {
        public DataTable ADLstMotCancelacion(int idModulo)
        {
            return new clsGENEjeSP().EjecSP("CRE_LstMotCancelacion_Sp", idModulo);
        }
    }
}
