using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADServicioGiros
    {
        //--=========================================================================
        //--Reporte de Giros
        //--=========================================================================
        public DataTable ADDatosGiros(DateTime dFechaIni, DateTime dFechaFin,int idEstablecimiento,int idEstado,int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("SER_RptListarGiros_Sp", dFechaIni, dFechaFin, idEstablecimiento, idEstado,idMoneda);
        }
    }
}
