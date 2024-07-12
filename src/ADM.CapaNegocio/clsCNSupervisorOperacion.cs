using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNSupervisorOperacion
    {
        clsADSupervisorOperacion objSupervisor = new clsADSupervisorOperacion();

        public DataTable CNListarSupervisorOperacion(string cTipoSupervision, DateTime dFechaIni, DateTime dFechaFin, int idRegion, int idAgencia, int idEstablecimiento, int idEstado)
        {
            return objSupervisor.ADListarSupervisorOperacion(cTipoSupervision, dFechaIni, dFechaFin, idRegion, idAgencia, idEstablecimiento, idEstado);
        }
    }
}
