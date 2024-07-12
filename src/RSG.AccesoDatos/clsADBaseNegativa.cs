using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RSG.AccesoDatos
{
    public class clsADBaseNegativa
    {
        public DataTable BaseNegativa(DateTime dFechaIni, DateTime dFechaFin, int nTipoReporte, int idZona, int idAgencia, int idPerfil)
        {
            return new clsGENEjeSP().EjecSP("RSG_ReporteBaseNegativa_SP", dFechaIni, dFechaFin, nTipoReporte, idZona, idAgencia, idPerfil);
        }
    }
}
