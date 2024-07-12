using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADLimiteOperativCred
    {
        public DataTable GetLimitesAsesor(int idUsuario,int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CRE_GetLimitesOperativosAsesor_Sp", idUsuario, idAgencia);
        }
    }
}
