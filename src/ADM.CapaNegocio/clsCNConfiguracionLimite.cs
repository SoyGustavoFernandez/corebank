using ADM.AccesoDatos;
using EntityLayer;
using System;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNConfiguracionLimite
    {
        public clsADConfiguracionLimite clsConfiguracionLimite = new clsADConfiguracionLimite();

        public DataTable CNListarConfiguracionLimite()
        {
            return clsConfiguracionLimite.ADListarConfiguracionLimite();
        }

        public DataTable CNMantenimientoConfiguracionLimite(clsConfiguracionLimite _clsConfiguracionLimite)
        {
            return clsConfiguracionLimite.ADMantenimientoConfiguracionLimite(_clsConfiguracionLimite);
        }
        
        public DataTable CNCargarTipoLimitesExcepciones()
        {
            return clsConfiguracionLimite.ADCargarTipoLimitesExcepciones();
        }
        
        public DataTable CNCargarTiposOperacionesLimites()
        {
            return clsConfiguracionLimite.ADCargarTiposOperacionesLimites();
        }

        public DataTable CNObtenerDatosRPTLimitesEOB(DateTime dFechaDesde, DateTime dFechaHasta, int idTipoLimite, int idAgencia, int idEstablecimiento)
        {
            return clsConfiguracionLimite.ADObtenerDatosRPTLimitesEOB(dFechaDesde, dFechaHasta, idTipoLimite, idAgencia, idEstablecimiento);
        }
    }
}
