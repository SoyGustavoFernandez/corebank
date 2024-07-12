using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADMonitorOtorgamientoCred
    {
       clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public clsADMonitorOtorgamientoCred()
        {

        }

        public List<clsResumOtorgamientosEtapa> ObtSegmtoFlujoOtorgCredEtapa(int idUsuario, int idAgencia, int idZona, int nTipoConsulta)
        {
            DataTable dtRes = objEjeSp.EjecSP("CRE_SeguimientoFlujoOtorgamiento_SP", idUsuario, idAgencia, idZona, nTipoConsulta);
            return DataTableToList.ConvertTo<clsResumOtorgamientosEtapa>(dtRes) as List<clsResumOtorgamientosEtapa>;
        }

        public List<clsResumOtorgamientosNivel> ObtSegmtoFlujoOtorgCredNivel(int idUsuario, int idAgencia, int idZona, int nTipoConsulta)
        {
            DataTable dtRes = objEjeSp.EjecSP("CRE_SeguimientoFlujoOtorgamiento_SP", idUsuario, idAgencia, idZona, nTipoConsulta);
            return DataTableToList.ConvertTo<clsResumOtorgamientosNivel>(dtRes) as List<clsResumOtorgamientosNivel>;
        }

        public DataSet ObtenerRanksOtorgaminetoCreditos(int idZona)
        {
            return objEjeSp.DSEjecSP("CRE_GenerarRankingCreditos_SP", idZona);
        }

        public DataTable SeguimientoSolicitudCred(int idUsuario, int idAgencia, int idZona, int nTipoConsulta, int nIndiceTabla)
        {
            return objEjeSp.EjecSP("CRE_SeguimientoSolicitudCred_SP", idUsuario, idAgencia, idZona, nTipoConsulta, nIndiceTabla);
        }

        public DataTable RptMonitorOtorgamientoCred(int idUsuario, int idAgencia, int idZona, int nTipoConsulta)
        {
            return objEjeSp.EjecSP("RPT_MonitorOtorgamientoCred_SP", idUsuario, idAgencia, idZona, nTipoConsulta);
        }

        public DataTable RptAmortizacionesEsperadas(DateTime dFechaSistema, int idAgencia, int idZona)
        {
            return objEjeSp.EjecSP("RPT_AmortizacionesEsperadas_SP", dFechaSistema, idAgencia, idZona);
        }

        public DataTable RptCancelacionesEsperadas(DateTime dFechaSistema, int idAgencia, int idZona)
        {
            return objEjeSp.EjecSP("RPT_CancelacionesEsperadas_SP", dFechaSistema, idAgencia, idZona);
        }

        public DataSet RptSeguimientoDiarioColocaciones(DateTime dFechaSistema, int idAgencia, int idZona)
        {
            return objEjeSp.DSEjecSP("RPT_SeguimientoDiarioColocaciones_SP", dFechaSistema, idAgencia, idZona);
        }
    }
}
