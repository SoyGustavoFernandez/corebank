using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNServicioGiros
    {
        clsRPTADServicioGiros ADDeposito = new clsRPTADServicioGiros();

        //--=========================================================================
        //--Reporte de Giros
        //--=========================================================================
        public DataTable CNDatosGiros(DateTime dFechaIni, DateTime dFechaFin, int idEstablecimiento, int idEstado, int idMoneda)
        {
            return ADDeposito.ADDatosGiros(dFechaIni, dFechaFin, idEstablecimiento, idEstado,idMoneda);
        }
    }
}
