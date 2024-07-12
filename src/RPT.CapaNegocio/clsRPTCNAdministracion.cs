using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;

namespace RPT.CapaNegocio
{
    public class clsRPTCNAdministracion
    {
        clsRPTADAdministracion objAdministracion = new clsRPTADAdministracion();

        public DataTable CNListarRegistrosRastreo(int idModulo, int idMenu, DateTime dFecHorInicio, DateTime dFecHorFinal)
        {
            return objAdministracion.ADListarRegistrosRastreo(idModulo, idMenu, dFecHorInicio, dFecHorFinal);
        }
    }
}
