using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.AccesoDatos
{
    public class clsRPTADSolicitud
    {
        clsGENEjeSP objejecuta = new clsGENEjeSP();

        public DataTable ADRptHojaResumen(int idSolicitud)
        {
            return objejecuta.EjecSP("CRE_RptHojaResumen_SP", idSolicitud);
        }

        public DataTable ADRptSolicitud(int idZonaGlobal,int idAgenciaGlobal,int nIdAsesor, int nIdProducto, DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objejecuta.EjecSP("CRE_ReporteSolicitudes_Sp", idZonaGlobal, idAgenciaGlobal, nIdAsesor, nIdProducto, dFechaDesde, dFechaHasta);
        }
        public DataTable ADRptHojaResumenPlanPago(int idSolicitud)
        {
            return objejecuta.EjecSP("CRE_PpgSolicitudImp_SP", idSolicitud);
        }
    }
}
