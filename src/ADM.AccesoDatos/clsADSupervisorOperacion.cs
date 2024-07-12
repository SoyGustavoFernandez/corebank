using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace ADM.AccesoDatos
{
    public class clsADSupervisorOperacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarSupervisorOperacion(string cTipoSupervision, DateTime dFechaIni, DateTime dFechaFin, int idRegion, int idAgencia, int idEstablecimiento, int idEstado)
        {
            return objEjeSp.EjecSP("CAJ_ListarSupervisorZona_SP", cTipoSupervision, dFechaIni, dFechaFin, idRegion, idAgencia, idEstablecimiento, idEstado);
        }
    }
}
