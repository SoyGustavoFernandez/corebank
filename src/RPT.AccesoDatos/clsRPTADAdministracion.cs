using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADAdministracion
    {
        public DataTable ADListarRegistrosRastreo(int idModulo, int idMenu, DateTime dFecHorInicio, DateTime dFecHorFinal)
        {
            return new clsGENEjeSP().EjecSP("RPT_ListarRegistrosRastreo_SP", idModulo, idMenu, dFecHorInicio, dFecHorFinal);
        }
    }
}
