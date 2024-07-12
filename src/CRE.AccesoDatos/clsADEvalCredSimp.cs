#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper;
#endregion

namespace CRE.AccesoDatos
{
    public class clsADEvalCredSimp
    {
        #region Variables Globales
        IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADEvalCredSimp()
        {
            objEjeSp = new clsGENEjeSP();
        }
        #endregion

        #region Facilito
        public DataSet ADBuscarEvalCreditoFacilito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalCredSimpFacilito_SP", idEvalCred);
        }

        public DataSet ADInicializarCredFacilito()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarEvalCredSimpFacilito_SP");
        }

        public DataSet ADRecuperarEvalCreditoFacilito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuEvalPyme_Sp", idEvalCred);
        }

        public DataTable ADActualizarEvalFacilito(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlRcc, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalCredSimpFacilito_SP", idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlRcc, xmlIndicadorEval);
        }

        public DataTable ADEnviarAComiteCreditosFacilito(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable ADGuardarHistoricoEstResEvalFacilito(int idEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarHistEstResEval_Sp", idEvalCred, idUsuario);
        }

        public DataTable ADValidarVisitasFacilito(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaVisitas_SP", idEvalCred);
        }

        public DataTable ADActEstFinancieroslEvalFacilito(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return objEjeSp.EjecSP("CRE_ActEstFinancieros_Sp", idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        public DataTable ADActDetalleEstadosResultadoslEvalFacilito(int idEvalCred, string xmlDetEstResEval, string xmlEvalSimpCDiario, string xmlEvalSimpCMensual, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ActDetEstResultadoSimpFacilito_SP", idEvalCred, xmlDetEstResEval, xmlEvalSimpCDiario, xmlEvalSimpCMensual, idUsuario);
        }

        public DataSet ADRecuperarDetalleEstResultadosEvalFacilito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuperarDetEstResultadosEvalSimpFacilito_SP", idEvalCred);
        }

        public DataSet ADRecuperarDetalleGeneralEstResultadosEvalFacilito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleGeneralEstResEvalSimpFacilito_Sp", idEvalCred);
        }

        public DataTable ADRecuperarDetalleSaldoInterviniente(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_RecuperarDetalleSaldoInterviniente_SP", idEvalCred);
        }

        public DataTable ADRecuperaMes()
        {
            return objEjeSp.EjecSP("CRE_RecuperaMes_SP");
        }

        public DataTable ADRecuperarTipoCicloMensual()
        {
            return objEjeSp.EjecSP("CRE_RecuperaTipoCicloMensual_SP");
        }

        public DataTable ADRecuperarConfigActividadEconomica(int idEvalCred)
        {
            return this.objEjeSp.EjecSP("CRE_RecuperaConfigActividadEconomica_SP", idEvalCred);
        }
        #endregion
    }
}
