using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNSeleccionarDocEvalAnterior
    {
        clsADSeleccionarDocEvalAnterior objSelectDocEval = new clsADSeleccionarDocEvalAnterior();

        public DataTable CNOptenerDocEvalAnterior(int idSolicitudAnterior, int idSolicitud, int idTipEvalConfig)
        {
            return objSelectDocEval.ADOptenerDocEvalAnterior(idSolicitudAnterior, idSolicitud, idTipEvalConfig);
        }

        public DataTable CNVicularDocumentos(int idSolicitud, int idSolicitudAnterior, int idUsuario, int idPerfil, int idAgencia, int idTipEvalConfig, string xmlArchivos)
        {
            return objSelectDocEval.ADVincularDocumentos(idSolicitud, idSolicitudAnterior, idUsuario, idPerfil, idAgencia, idTipEvalConfig, xmlArchivos);
        }

        #region Evaluacion Presencial-remota
        public DataTable CNListaTipoEvaluacion()
        {
            return this.objSelectDocEval.ADListaTipoEvaluacion();
        }

        public DataTable  CNRecuperaSolicitudAnterior(int idCli, DateTime dFechaActual, string cIdTipEvalCred, int idTipEvalConfig)
        {
            return this.objSelectDocEval.ADRecuperaSolicitudAnterior(idCli, dFechaActual, cIdTipEvalCred, idTipEvalConfig);
        }

        public DataTable CNActualizaInformacionEvaluacion(int idEvalCredActual, int idEvalCredAnterior, int idTipEvalConfig, string cIdTipEvalCred)
        {
            return this.objSelectDocEval.ADActualizaInformacionEvaluacion(idEvalCredActual, idEvalCredAnterior, idTipEvalConfig, cIdTipEvalCred);
        }
        #endregion
    }
}
