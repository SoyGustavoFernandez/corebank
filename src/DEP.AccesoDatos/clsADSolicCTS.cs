using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;


namespace DEP.AccesoDatos
{
    public class clsADSolicCTS
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public void EnviarSolicitud(int idCuenta, int idCli, int idTipEntidad, int idEntidad, int idMonOrigen,
                                        int idAgencia, int idPromotor, int idMonDestino, int idCliEmple,
                                        int idUsuario, DateTime DfechaSolic, int nTipoTraslado)
        {
            objEjeSp.EjecSP("DEP_SolicTraslCTS_sp", idCuenta, idCli, idTipEntidad, idEntidad, idMonOrigen,
                                         idAgencia, idPromotor, idMonDestino, idCliEmple,
                                         idUsuario, DfechaSolic, nTipoTraslado);
        }
        public void AnularSol(int idSolicitud)
        {
            objEjeSp.EjecSP("DEP_AnularSolicCTS_sp", idSolicitud);
        }
        public DataTable DatosSolici(int idCli, int nTipoTraslado)
        {
            return objEjeSp.EjecSP("DEP_DatosSolicCTS_sp", idCli, nTipoTraslado);
        }
        public DataTable ListSoliciPend()
        {
            return objEjeSp.EjecSP("DEP_ListSolicTraslCTS_sp");
        }
        public DataTable CtaDuplicado(int idCli, int idCliEmpl)
        {
            return objEjeSp.EjecSP("DEP_ExisteCtaCTS_sp",idCli, idCliEmpl);
        }
        public void AprobRechaz(int idEstado, int idSolic, int idUsuAprob, DateTime dFecAprob, string txtobservacion)
        {
            objEjeSp.EjecSP("DEP_AprobSolicTraslCTS_sp", idEstado, idSolic, idUsuAprob, dFecAprob, txtobservacion);
        }
        public DataTable ADCtaEsCTS(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_CtaEsCTS_SP", idCuenta);
        }
        public DataTable ADRegSoliciCTSCarta(int idSolCTS, decimal nMonto, string cViaEntidad, int idTipoComprobante, DateTime dFechaOperacion, string cNroOperacion, string cNroCtaOCheque, decimal nImporte, int idUsuario)
        {
            return objEjeSp.EjecSP("DEP_RegSolicTraslCartaCTS_SP", idSolCTS, nMonto, cViaEntidad, idTipoComprobante, dFechaOperacion, cNroOperacion, cNroCtaOCheque, nImporte, idUsuario);
        }
        public DataTable ADDatosSoliciCTSCarta(int idSolCTS)
        {
            return objEjeSp.EjecSP("DEP_ObtenerSolicTraslCartaCTS_SP", idSolCTS);
        }
        public DataTable ADListarTipComprobantePagoCTS()
        {
            return objEjeSp.EjecSP("DEP_ListTipComprobantePagoCTS_SP");
        }
        public DataTable ADRptSolicTraslCartaCTS(int idSolCTS, int idAgencia)
        {
            return objEjeSp.EjecSP("RPT_RptSolicTraslCartaCTS_SP", idSolCTS, idAgencia);
        }
        public DataTable ADRptTrasladosCtasCTS(DateTime dFechaInicio, DateTime dFechaFin, int idEstado, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_RptTrasladosCtasCTS_SP", dFechaInicio, dFechaFin, idEstado, idAgencia);
        }
        public DataTable ADRptCartasCTS(DateTime dFechaInicio, DateTime dFechaFin, int idAgencia)
        {
            return objEjeSp.EjecSP("DEP_RptCartasCTS_SP", dFechaInicio, dFechaFin, idAgencia);
        }
        public DataTable ADListarEstadosSolicitudCTS()
        {
            return objEjeSp.EjecSP("DEP_ListarEstadosSolicitudCTS_SP");
        }
        public DataTable ADDatosCuentaCTSCancelado(int idCuenta)
        {
            return objEjeSp.EjecSP("DEP_RetornaDatosCuentaCTSCancelado_sp", idCuenta);
        }

        public DataTable ADListSoliciAproba(int Estado)
        {
            return objEjeSp.EjecSP("DEP_ListSolicAproCTS_sp", Estado);
        }

        public DataTable ADValidaCTSCli(string idCli)
        {
            return objEjeSp.EjecSP("DEP_ValidaCtaCTS_SP", idCli);
        }
    }
}
