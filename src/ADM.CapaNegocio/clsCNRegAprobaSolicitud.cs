using ADM.AccesoDatos;
using System;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNRegAprobaSolicitud
    {
        clsADRegAprobaSolicitud clsADRegAprobaSolicitud = new clsADRegAprobaSolicitud();

        public DataTable CNRegistarSolicitudExcepcionLimite(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol,
                                            DateTime dFecAprSol, int idUsuRegist, int IExcepcion,
                                            int idTipoOpeExp, string cLimiteExcep, int idEstablecimiento)
        {
            return clsADRegAprobaSolicitud.ADRegistarSolicitudExcepcionLimite(idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda, idProducto, nValAproba, idDocument, dFecSolici,
                idMotivo, cSustento, idEstadoSol, dFecAprSol, idUsuRegist, IExcepcion, idTipoOpeExp, cLimiteExcep, idEstablecimiento);
        }
        
        public DataTable CNObtenerAprobadorSolExcep(int idSolAproba)
        {
            return clsADRegAprobaSolicitud.ADObtenerAprobadorSolExcep(idSolAproba);
        }

        public DataTable CNEnviarEmailLimiteEOB(int idSolAproba)
        {
            return clsADRegAprobaSolicitud.ADOEnviarEmailLimiteEOB(idSolAproba);
        }

        public DataTable CNObtenerSolExcepcion(int idUsuario, DateTime fechaInicio, DateTime fechaActual)
        {
            return clsADRegAprobaSolicitud.ADObtenerSolExcepcion(idUsuario, fechaInicio, fechaActual);
        }

        public DataTable CNActualizarAprobadorSolExcep(int idSolAproba)
        {
            return clsADRegAprobaSolicitud.ADActualizarAprobadorSolExcep(idSolAproba);
        }

        public DataTable CNAnularAprobadorSolExcep(int idSolAproba)
        {
            return clsADRegAprobaSolicitud.ADAnularAprobadorSolExcep(idSolAproba);
        }
    }
}
