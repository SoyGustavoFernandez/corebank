using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;
using GEN.CapaNegocio;

namespace DEP.CapaNegocio
{
    public class clsCNSolicCTS
    {
        public clsADSolicCTS SolicTraslCTS = new clsADSolicCTS();
        public void EnviarSolicitud(int idCuenta, int idCli, int idTipEntidad, int idEntidad, int idMonOrigen, 
                                        int idAgencia, int idPromotor, int idMonDestino,  int idCliEmple, 
                                        int idUsuario, DateTime DfechaSolic, int nTipoTraslado)
        {
            SolicTraslCTS.EnviarSolicitud(idCuenta, idCli,  idTipEntidad,  idEntidad,  idMonOrigen, 
                                         idAgencia,  idPromotor,  idMonDestino,   idCliEmple,
                                         idUsuario, DfechaSolic, nTipoTraslado);
        }

        public void AnularSol(int idSolicitud)
        {
            SolicTraslCTS.AnularSol(idSolicitud);
        }
        public DataTable DatosSolici(int idCli, int nTipoTraslado)
        {
            return SolicTraslCTS.DatosSolici(idCli, nTipoTraslado);
        }
        public DataTable ListSoliciPend()
        {
            return SolicTraslCTS.ListSoliciPend();
        }
        public DataTable CtaDuplicado(int idCli, int idCliEmpl)
        {
            return SolicTraslCTS.CtaDuplicado(idCli, idCliEmpl);
        }
        public void AprobRechaz(int idEstado, int idSolic, int idUsuAprob, DateTime dFecAprob, string txtobservacion)
        {
            SolicTraslCTS.AprobRechaz(idEstado, idSolic, idUsuAprob, dFecAprob, txtobservacion);
        }
        public DataTable CNCtaEsCTS(int idCuenta)
        {
            return SolicTraslCTS.ADCtaEsCTS(idCuenta);
        }
        public DataTable CNRegSoliciCTSCarta(int idSolCTS, decimal nMonto, string cViaEntidad, int idTipoComprobante, DateTime dFechaOperacion, string cNroOperacion, string cNroCtaOCheque, decimal nImporte, int idUsuario)
        {
            return SolicTraslCTS.ADRegSoliciCTSCarta(idSolCTS, nMonto, cViaEntidad, idTipoComprobante, dFechaOperacion, cNroOperacion, cNroCtaOCheque, nImporte, idUsuario);
        }
        public DataTable CNDatosSoliciCTSCarta(int idSolCTS)
        {
            return SolicTraslCTS.ADDatosSoliciCTSCarta(idSolCTS);
        }
        public DataTable CNListarTipComprobantePagoCTS()
        {
            return SolicTraslCTS.ADListarTipComprobantePagoCTS();
        }
        public DataTable CNRptSolicTraslCartaCTS(int idSolCTS, int idAgencia)
        {
            return SolicTraslCTS.ADRptSolicTraslCartaCTS(idSolCTS, idAgencia);
        }
        public DataTable CNRptTrasladosCtasCTS(DateTime dFechaInicio, DateTime dFechaFin, int idEstado, int idAgencia)
        {
            return SolicTraslCTS.ADRptTrasladosCtasCTS(dFechaInicio, dFechaFin, idEstado, idAgencia);
        }
        public DataTable CNRptCartasCTS(DateTime dFechaInicio, DateTime dFechaFin, int idAgencia)
        {
            return SolicTraslCTS.ADRptCartasCTS(dFechaInicio, dFechaFin, idAgencia);
        }
        public DataTable CNListarEstadosSolicitudCTS()
        {
            return SolicTraslCTS.ADListarEstadosSolicitudCTS();
        }
        public DataTable CNDatosCuentaCTSCancelado(int idCuenta)
        {
            return SolicTraslCTS.ADDatosCuentaCTSCancelado(idCuenta);
        }

        public DataTable ListSoliciAproba(int Estado)
        {
            return SolicTraslCTS.ADListSoliciAproba(Estado);
        }

        public bool CNValidaCTSCli(string idCli)
        {
            DataTable dtValidaCts=SolicTraslCTS.ADValidaCTSCli(idCli);
            if (Convert.ToInt16(dtValidaCts.Rows[0]["idRpta"])==1)
            {
                return true;
            }
            return false;
        }

    }
}
