using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADSeleccionarDocEvalAnterior
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADOptenerDocEvalAnterior(int idSolicitudAnterior, int idSolicitud, int idTipEvalConfig)
        {
            return objEjeSp.EjecSP("CRE_ObtineDocumentosUltimaEval_SP", idSolicitudAnterior, idSolicitud, idTipEvalConfig);
        }

        public DataTable ADVincularDocumentos(int idSolicitud, int idSolicitudAnterior, int idUsuario, int idPerfil, int idAgencia, int idTipEvalConfig, string xmlArchivos)
        {
            return objEjeSp.EjecSP("CRE_VinculaDocumentosUltimaEval_SP", idSolicitud, idSolicitudAnterior, idUsuario, idPerfil, idAgencia, idTipEvalConfig, xmlArchivos);
        }

        #region Evaluacion Presencial-remota
        public DataTable ADListaTipoEvaluacion()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoEvaluacion_SP");
        }

        public DataTable ADRecuperaSolicitudAnterior(int idCli, DateTime dFechaActual, string cIdTipEvalCred, int idTipEvalConfig)
        {
            return objEjeSp.EjecSP("CRE_ObtieneCantidadAntiguaSoli_SP", idCli, dFechaActual, cIdTipEvalCred, idTipEvalConfig);
        }

        public DataTable ADActualizaInformacionEvaluacion(int idEvalCredActual, int idEvalCredAnterior, int idTipEvalConfig, string cIdTipEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ActualizaInformacionEvaluacionActual_SP", idEvalCredActual, idEvalCredAnterior, idTipEvalConfig, cIdTipEvalCred);
        }
        #endregion
    }
}
