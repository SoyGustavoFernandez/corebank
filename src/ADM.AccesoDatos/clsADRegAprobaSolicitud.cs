using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADRegAprobaSolicitud
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADRegistarSolicitudExcepcionLimite(int idAgencia, int idCliente, int idTipoOperacion,
                                            int idEstadoOperac, int idMoneda, int idProducto,
                                            Decimal nValAproba, int idDocument, DateTime dFecSolici,
                                            int idMotivo, String cSustento, int idEstadoSol, DateTime dFecAprSol, int idUsuRegist,
                                            int IExcepcion, int idTipoOpeExp, string cLimiteExcep, int idEstablecimiento, int idPerfil = 0)

        {

            return new clsGENEjeSP().EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, idTipoOperacion, idEstadoOperac, idMoneda,
                                                                      idProducto, nValAproba, idDocument, dFecSolici, idMotivo, cSustento,
                                                                      idEstadoSol, dFecAprSol, idUsuRegist, IExcepcion,
                                                                      idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }

        public DataTable ADObtenerAprobadorSolExcep(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("ADM_ObtenerAprobSolExcep_SP", idSolAproba);
        }

        public DataTable ADOEnviarEmailLimiteEOB(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("CAJ_EnviarEmailLimitesEOB_SP", idSolAproba);
        }

        public DataTable ADObtenerSolExcepcion(int idUsuario, DateTime fechaInicio, DateTime fechaActual)
        {
            return new clsGENEjeSP().EjecSP("ADM_ObtenerSolExcepcion_SP", idUsuario, fechaInicio, fechaActual);
        }

        public DataTable ADActualizarAprobadorSolExcep(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("ADM_ActualizarAprobaSoliciExcep_SP", idSolAproba);
        }

        public DataTable ADAnularAprobadorSolExcep(int idSolAproba)
        {
            return new clsGENEjeSP().EjecSP("ADM_EliminarAprobaSoliciExcep_SP", idSolAproba);
        }
    }
}