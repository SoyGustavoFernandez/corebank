using RPT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.CapaNegocio
{
    public class clsRPTCNSolicitud
    {
        clsRPTADSolicitud rptadsolicitud = new clsRPTADSolicitud();

        public DataTable CNRptHojaResumen(int idSolicitud)
        {
            return rptadsolicitud.ADRptHojaResumen(idSolicitud);
        }
        public DataTable CNRptSolicitud(int idZonaGlobal,int idAgenciaGlobal,int nIdAsesor,int nIdProducto,DateTime dFechaDesde,DateTime dFechaHasta)
        {
            return rptadsolicitud.ADRptSolicitud(idZonaGlobal, idAgenciaGlobal, nIdAsesor, nIdProducto, dFechaDesde, dFechaHasta);
        }
        public DataTable CNRptHojaResumenPlanPago(int idSolicitud)
        {
            return rptadsolicitud.ADRptHojaResumenPlanPago(idSolicitud);
        }
    }
}
