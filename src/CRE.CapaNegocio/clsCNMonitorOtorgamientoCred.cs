using CRE.AccesoDatos;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNMonitorOtorgamientoCred
    {
        clsADMonitorOtorgamientoCred objADMonitorOtorgCred = new clsADMonitorOtorgamientoCred();
        public clsCNMonitorOtorgamientoCred()
        {

        }

        public List<clsResumOtorgamientosEtapa> ObtSegmtoFlujoOtorgCredEtapa(int idUsuario, int idAgencia, int idZona, int nTipoConsulta)
        {
            return objADMonitorOtorgCred.ObtSegmtoFlujoOtorgCredEtapa(idUsuario, idAgencia, idZona, nTipoConsulta);
        }

        public List<clsResumOtorgamientosNivel> ObtSegmtoFlujoOtorgCredNivel(int idUsuario, int idAgencia, int idZona, int nTipoConsulta)
        {
            return objADMonitorOtorgCred.ObtSegmtoFlujoOtorgCredNivel(idUsuario, idAgencia, idZona, nTipoConsulta);
        }

        public DataSet ObtenerRanksOtorgaminetoCreditos(int idZona)
        {
            return objADMonitorOtorgCred.ObtenerRanksOtorgaminetoCreditos(idZona);
        }

        public DataTable SeguimientoSolicitudCred(int idUsuario, int idAgencia, int idZona, int nTipoConsulta, int nIndiceTabla)
        {
            return objADMonitorOtorgCred.SeguimientoSolicitudCred(idUsuario, idAgencia, idZona, nTipoConsulta, nIndiceTabla);
        }

        public DataTable RptMonitorOtorgamientoCred(int idUsuario, int idAgencia, int idZona, int nTipoConsulta)
        {
            return objADMonitorOtorgCred.RptMonitorOtorgamientoCred(idUsuario, idAgencia, idZona, nTipoConsulta);
        }

        public DataTable RptAmortizacionesEsperadas(DateTime dFechaSistema, int idAgencia, int idZona)
        {
            return objADMonitorOtorgCred.RptAmortizacionesEsperadas(dFechaSistema, idAgencia, idZona);
        }

        public DataTable RptCancelacionesEsperadas(DateTime dFechaSistema, int idAgencia, int idZona)
        {
            return objADMonitorOtorgCred.RptCancelacionesEsperadas(dFechaSistema, idAgencia, idZona);
        }

        public DataSet RptSeguimientoDiarioColocaciones(DateTime dFechaSistema, int idAgencia, int idZona)
        {
            return objADMonitorOtorgCred.RptSeguimientoDiarioColocaciones(dFechaSistema, idAgencia, idZona);
        }
    }
}
