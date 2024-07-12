using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADConfiguracionLimite
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarConfiguracionLimite()
        {
            return objEjeSp.EjecSP("ADM_ObtenerConfigLimiteExcep_SP");
        }

        public DataTable ADMantenimientoConfiguracionLimite(clsConfiguracionLimite clsConfiguracionLimite)
        {
            return objEjeSp.EjecSP("ADM_MantenimientoConfigLimExcep_SP", clsConfiguracionLimite.idConfig, clsConfiguracionLimite.idTipoOpe, clsConfiguracionLimite.idLimiteExcep, clsConfiguracionLimite.nLimiteInferior,
                clsConfiguracionLimite.nLimiteSuperior, clsConfiguracionLimite.lVigente, clsConfiguracionLimite.nUsuario);
        }

        public DataTable ADCargarTipoLimitesExcepciones()
        {
            return objEjeSp.EjecSP("ADM_ObtenerTipoLimiteExcep_SP");
        }

        public DataTable ADCargarTiposOperacionesLimites()
        {
            return objEjeSp.EjecSP("ADM_ObtenerTipoOperacionEOB_SP");
        }

        public DataTable ADObtenerDatosRPTLimitesEOB(DateTime dFechaDesde, DateTime dFechaHasta, int idTipoLimite, int idAgencia, int idEstablecimiento)
        {
            return objEjeSp.EjecSP("CRE_ObtenerRTPLimitesEOB_SP", dFechaDesde, dFechaHasta, idTipoLimite, idAgencia, idEstablecimiento);
        }
    }
}
