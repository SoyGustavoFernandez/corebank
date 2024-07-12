using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADSolicitudRecuperacion 
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarSolicitudRecuperacion()
        {
            return objEjeSp.EjecSP("RCP_ListarSolicitudRecuperacion_SP");
        }

        public DataTable ListarSolicitudRecuperacionid(int idSolicitudRecuperacion)
        {
            return objEjeSp.EjecSP("RCP_ListarSolicitudRecuperacionidSolicitudRecuperacion_SP", idSolicitudRecuperacion);
        }

        public DataTable InsertarSolicitudRecuperacion(int idCuenta, int idEstadoSolRec, DateTime dFechaReg, int idUsuReg, DateTime dFechaMod, int idUsuMod, int idCli, int idMotivoMora, string cObservaciones, string cOpinionTransferencia)
        {
            return objEjeSp.EjecSP("RCP_InsertarSolicitudRecuperacion_SP", idCuenta, idEstadoSolRec, dFechaReg, idUsuReg, dFechaMod, idUsuMod, idCli, idMotivoMora, cObservaciones, cOpinionTransferencia);
        }

        public DataTable InsertSolicitudPasoJudicial(int idCuenta, int idEstadoSolRec, DateTime dFechaReg, int idUsuReg, DateTime dFechaMod,
                                                     int idUsuMod, string cJustificacion, int idCli, object DocJudicial, string cNombreArchivo, int nIdInformeJudicial)
        {

            return objEjeSp.EjecSP("RCP_InsertarSolicitudJudicial_SP", idCuenta, idCli, idEstadoSolRec, cJustificacion, dFechaReg, idUsuReg, dFechaMod,
                                                                    idUsuMod, DocJudicial, cNombreArchivo, nIdInformeJudicial);
        }

        public DataTable InsertarSolicitudExtrajudicial(int idCuenta, int idUsuario, int nIdAgencia, string txtJustificacion, string txtNumRea1,
                                                        DateTime dFechaSolicitud, int nCuotas, DateTime dFechaPrimeraCuota, int nTipoPeriodo,
                                                        int nDiaPago, DateTime dFechaRegistro, string cNombreArchivo, string cRenombreArchivo, object DocExtrajudicial)
        {
            DataTable datos = objEjeSp.EjecSP("RCP_InsertarSolicitudExtrajudicial_SP", idCuenta, idUsuario, nIdAgencia, txtJustificacion, txtNumRea1, dFechaSolicitud,
                                                                    nCuotas, dFechaPrimeraCuota, nTipoPeriodo, nDiaPago, dFechaRegistro, cNombreArchivo, cRenombreArchivo, DocExtrajudicial);
            return datos;
        }

        public DataTable ActualizarSolicitudRecuperacion(int idCuenta, int idEstadoSolRec, DateTime dFechaReg, int idUsuReg, DateTime dFechaMod, int idUsuMod, int idSolicitudRecuperacion)
        {
            return objEjeSp.EjecSP("RCP_ActualizarSolicitudRecuperacion_SP", idCuenta, idEstadoSolRec, dFechaReg, idUsuReg, dFechaMod, idUsuMod, idSolicitudRecuperacion);
        }

        public DataTable ListarDetalleSolicitudRecid(int idSolicitudRecuperacion)
        {
            return objEjeSp.EjecSP("RCP_ListarDetalleSolicitudRecidSolicitudRecuperacion_SP", idSolicitudRecuperacion);
        }

        public DataTable InsertarDetalleSolicitudRec(int idSolicitudRecuperacion, int idEstadoSolRec, DateTime dFechaMod, int idUsuMod)
        {
            return objEjeSp.EjecSP("RCP_InsertarDetalleSolicitudRec_SP", idSolicitudRecuperacion, idEstadoSolRec, dFechaMod, idUsuMod);
        }

        public DataTable ListarSoliRecuperaPendiAprob(int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_ListarSoliRecuperaPendiAprob_SP", idAgencia);
        }

        public DataTable ListarSoliRecuperaPendiAprobJudicial()
        {
            return objEjeSp.EjecSP("RCP_ListarSoliRecuperaPendiAprobJudicial_SP");
        }

        public DataTable BuscarDocSolicitudJudicial(int idSolicitudJudicial)
        {
            return objEjeSp.EjecSP("SP_DocumentoAdjuntosJudicial_SP", idSolicitudJudicial); ;
        }
        public DataTable AprobarSolicitudJudicial(int idSolicitud, int idCuenta, int idGestor, int idUsuarioAsigna, int idEstadoSolJudicial, int nAprob)
        {
            return objEjeSp.EjecSP("RCP_AprobarSolicitudJudicial_SP", idSolicitud, idCuenta, idGestor, idUsuarioAsigna, idEstadoSolJudicial, nAprob);
        }
        
        public DataTable AprobarSolicitudRecuperacion(string xmlSolRecupera)
        {
            return objEjeSp.EjecSP("RCP_AprobarSolicitudRecuperacion_SP", xmlSolRecupera);
        }

        public DataTable LisCreRecuperaxCli(int idCli)
        {
            return objEjeSp.EjecSP("RCP_LisCreRecuperaxCli_sp", idCli);
        }
        public DataTable LisCrePasoExtrajudicial(int idCli,int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_LisCrePasoExtrajudicial_SP", idCli,idUsuario);
        }
        public DataTable CreditoExtrajudicial(int idCli)
        {
            return objEjeSp.EjecSP("RCP_CreditoExtrajudicial_SP", idCli);
        }

        public DataTable CongelarCreditoExtrajudicial(int nCuenta)
        {
            return objEjeSp.EjecSP("RCP_CongelarTasaInteresExtrajudicial_SP", nCuenta);
        }

        public DataTable DatosCreTransRecupera(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_DatosCreTransRecupera_SP", idCuenta);
        }

        public DataTable DatosIntervTransRecupera(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_DatosIntervTransRecupera_SP", idCuenta);
        }

        public DataTable EventosTransRecupera(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_EventosTransRecupera_SP", idCuenta);
        }

        public DataTable RptEventosTransRecuperaFiltro(DateTime dFecIni, DateTime dFecFin, int idRecuperador)
        {
            return objEjeSp.EjecSP("RCP_RptEventosTransRecuperaFiltro_SP", dFecIni, dFecFin, idRecuperador);
        }

        public DataTable ListarInformesPorCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_ListarInformesPorCuenta_SP", idCuenta);
        }
    }
}
