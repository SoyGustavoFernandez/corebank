using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG.AccesoDatos;
using System.Data;

namespace RSG.CapaNegocio
{
    public class clsCNBaseNegativa
    {
        public DataTable BaseNegativa(DateTime dFechaIni, DateTime dFechaFin, int nTipoReporte, int idZona, int idAgencia, int idPerfil)
        {
            return new clsADBaseNegativa().BaseNegativa(dFechaIni, dFechaFin, nTipoReporte, idZona, idAgencia, idPerfil);
        }
    }
}
