#region  Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.AccesoDatos;
using EntityLayer;
#endregion

namespace CRE.CapaNegocio
{
    public class clsCNEvalCredSimp
    {
        #region Variables Globales
        private clsADEvalCredSimp objADEvalCredSimp { get; set; }
        #endregion

        #region Constructor
        public clsCNEvalCredSimp()
        {
            objADEvalCredSimp = new clsADEvalCredSimp();
        }
        #endregion

        #region Facilito

        public DataSet CNBuscarEvalCreditoFacilito(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADBuscarEvalCreditoFacilito(idEvalCred);
        }

        public DataSet CNInicializarCredFacilito()
        {
            return this.objADEvalCredSimp.ADInicializarCredFacilito();
        }

        public DataSet CNRecuperarEvalCreditoFacilito(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADRecuperarEvalCreditoFacilito(idEvalCred);
        }

        public DataTable CNActualizarEvalFacilito(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return this.objADEvalCredSimp.ADActualizarEvalFacilito(idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataTable CNEnviarAComiteCreditosFacilito(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return this.objADEvalCredSimp.ADEnviarAComiteCreditosFacilito(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable CNGuardarHistoricoEstResEvalFacilito(int idEvalCred, int idUsuario)
        {
            return this.objADEvalCredSimp.ADGuardarHistoricoEstResEvalFacilito(idEvalCred, idUsuario);
        }

        public DataTable CNCNValidarVisitasFacilito(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADValidarVisitasFacilito(idEvalCred);
        }

        public DataTable CNActEstFinancieroslEvalFacilito(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return this.objADEvalCredSimp.ADActEstFinancieroslEvalFacilito(idEvalCred, xmlBalGenEval, xmlEstResEval);
        }
        public DataTable CNActDetalleEstadosResultadoslEvalFacilito(int idEvalCred, string xmlDetEstResEval, string xmlEvalSimpCDiario, string xmlEvalSimpCMensual, int idUsuario)
        {
            return this.objADEvalCredSimp.ADActDetalleEstadosResultadoslEvalFacilito(idEvalCred, xmlDetEstResEval, xmlEvalSimpCDiario, xmlEvalSimpCMensual, idUsuario);
        }
        public DataSet CNRecuperarDetalleEstResultadosEvalFacilito(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADRecuperarDetalleEstResultadosEvalFacilito(idEvalCred);
        }

        public DataSet CNRecuperarDetalleGeneralEstResultadosEvalFacilito(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADRecuperarDetalleGeneralEstResultadosEvalFacilito(idEvalCred);
        }

        public DataTable CNRecuperarDetalleSaldoInterviniente(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADRecuperarDetalleSaldoInterviniente(idEvalCred);
        }

        public DataTable CNRecuperaMes()
        {
            return this.objADEvalCredSimp.ADRecuperaMes();
        }

        public DataTable CNRecuperarTipoCicloMensual()
        {
            return this.objADEvalCredSimp.ADRecuperarTipoCicloMensual();
        }

        public DataTable CNRecuperarConfigActividadEconomica(int idEvalCred)
        {
            return this.objADEvalCredSimp.ADRecuperarConfigActividadEconomica(idEvalCred);
        }
        #endregion


    }
}
