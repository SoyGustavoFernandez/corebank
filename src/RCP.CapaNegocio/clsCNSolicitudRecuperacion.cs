using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNSolicitudRecuperacion 
    {
        clsADSolicitudRecuperacion solicitudrecupera = new clsADSolicitudRecuperacion();

        public DataTable ListarSolicitudRecuperacion()
        {
            return solicitudrecupera.ListarSolicitudRecuperacion();
        }

        public DataTable ListarSolicitudRecuperacionid(int idSolicitudRecuperacion)
        {
            return solicitudrecupera.ListarSolicitudRecuperacionid( idSolicitudRecuperacion);
        }

        public DataTable InsertarSolicitudRecuperacion(int idCuenta, int idEstadoSolRec, DateTime dFechaReg, int idUsuReg, DateTime dFechaMod, int idUsuMod, int idCli, int idMotivoMora, string cObservaciones, string cOpinionTransferencia)
        {
            return solicitudrecupera.InsertarSolicitudRecuperacion(idCuenta, idEstadoSolRec, dFechaReg, idUsuReg, dFechaMod, idUsuMod, idCli, idMotivoMora, cObservaciones, cOpinionTransferencia);
        }

        //Inserta Solicitud a Judicial
        public DataTable InsertSolicitudPasoJudicial(int idCuenta, int idEstadoSolRec, DateTime dFechaReg, int idUsuReg, DateTime dFechaMod,
                                                     int idUsuMod, string cJustificacion, int idCli, object DocJudicial, string cNombreArchivo, int nIdInformeJudicial)
        {
            return solicitudrecupera.InsertSolicitudPasoJudicial(idCuenta, idEstadoSolRec, dFechaReg, idUsuReg, dFechaMod,
                                                        idUsuMod, cJustificacion, idCli, DocJudicial, cNombreArchivo, nIdInformeJudicial);
        }


        public DataTable InsertarSolicitudExtrajudicial(int idCuenta,int idUsuario, int nIdAgencia,string txtJustificacion, string txtNumRea1,
                                                        DateTime dFechaSolicitud, int nCuotas, DateTime dFechaPrimeraCuota, int nTipoPeriodo,
                                                        int nDiaPago, DateTime dFechaRegistro, string cNombreArchivo,string cRenombreArchivo, object DocExtrajudicial)
        {
            
            return solicitudrecupera.InsertarSolicitudExtrajudicial(idCuenta,idUsuario, nIdAgencia,txtJustificacion, txtNumRea1,dFechaSolicitud,
                                                                    nCuotas, dFechaPrimeraCuota, nTipoPeriodo, nDiaPago, dFechaRegistro, cNombreArchivo, cRenombreArchivo, DocExtrajudicial);

        }

        public DataTable ActualizarSolicitudRecuperacion(int idCuenta, int idEstadoSolRec, DateTime dFechaReg, int idUsuReg, DateTime dFechaMod, int idUsuMod, int idSolicitudRecuperacion)
        {
            return solicitudrecupera.ActualizarSolicitudRecuperacion( idCuenta, idEstadoSolRec, dFechaReg, idUsuReg, dFechaMod, idUsuMod, idSolicitudRecuperacion);
        }

        public DataTable ListarDetalleSolicitudRecid(int idSolicitudRecuperacion)
        {
            return solicitudrecupera.ListarDetalleSolicitudRecid( idSolicitudRecuperacion);
        }

        public DataTable InsertarDetalleSolicitudRec(int idSolicitudRecuperacion, int idEstadoSolRec, DateTime dFechaMod, int idUsuMod)
        {
            return solicitudrecupera.InsertarDetalleSolicitudRec( idSolicitudRecuperacion, idEstadoSolRec, dFechaMod, idUsuMod);
        }

        public DataTable ListarSoliRecuperaPendiAprob(int idAgencia)
        {
            return solicitudrecupera.ListarSoliRecuperaPendiAprob(idAgencia);
        }

        public DataTable ListarSoliRecuperaPendiAprobJudicial()
        {
            return solicitudrecupera.ListarSoliRecuperaPendiAprobJudicial();
        }

        public DataTable BuscarDocSolicitudJudicial(int idSolicitudJudicial)
        {
            return solicitudrecupera.BuscarDocSolicitudJudicial(idSolicitudJudicial);
        }

        public DataTable AprobarSolicitudJudicial(int idSolicitud, int idCuenta, int idGestor, int idUsuarioAsigna, int idEstadoSolJudicial, int nAprob)
        {
            return solicitudrecupera.AprobarSolicitudJudicial(idSolicitud, idCuenta, idGestor, idUsuarioAsigna, idEstadoSolJudicial, nAprob);
        }

        public DataTable AprobarSolicitudRecuperacion(string xmlSolRecupera)
        {
            return solicitudrecupera.AprobarSolicitudRecuperacion(xmlSolRecupera);
        }

        public DataTable LisCreRecuperaxCli(int idCli)
        {
            return solicitudrecupera.LisCreRecuperaxCli(idCli);
        }
        public DataTable LisCrePasoExtrajudicial(int idCli, int idUsuario)
        {
            return solicitudrecupera.LisCrePasoExtrajudicial(idCli, idUsuario);
        }
        public DataTable CreditoExtrajudicial(int idCli)
        {
            return solicitudrecupera.CreditoExtrajudicial(idCli);
        }

        public DataTable CongelarCreditoExtrajudicial(int nCuenta)
        {
            return solicitudrecupera.CongelarCreditoExtrajudicial(nCuenta);
        }

        public DataTable DatosCreTransRecupera(int idCuenta)
        {
            return solicitudrecupera.DatosCreTransRecupera(idCuenta);
        }

        public DataTable DatosIntervTransRecupera(int idCuenta)
        {
            return solicitudrecupera.DatosIntervTransRecupera(idCuenta);
        }

        public DataTable EventosTransRecupera(int idCuenta)
        {
            return solicitudrecupera.EventosTransRecupera(idCuenta);
        }

        public DataTable RptEventosTransRecuperaFiltro(DateTime dFecIni, DateTime dFecFin, int idRecuperador)
        {
            return solicitudrecupera.RptEventosTransRecuperaFiltro(dFecIni, dFecFin, idRecuperador);
        }

        public DataTable ListarInformesPorCuenta(int idCuenta)
        {
            return solicitudrecupera.ListarInformesPorCuenta(idCuenta);
        }
    }
}
