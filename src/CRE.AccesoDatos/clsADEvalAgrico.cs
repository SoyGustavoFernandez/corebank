using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADEvalAgrico
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalAgrico_Sp", idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlDetEstResEval, string xmlIndicadorEval)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEvalAgrico_Sp", idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlDetEstResEval, xmlIndicadorEval);
        }

        public DataSet InicializarAgrico()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarAgrico_Sp");
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuEvalPyme_Sp", idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCredTemp, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCredTemp, lCanalAproCredEditable);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return objEjeSp.EjecSP("CRE_ActEstFinancieros_Sp", idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        /*public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleBalGenEval_Sp", idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, decimal nCajaInicial, string xmlDetBalGenEval)
        {
            return objEjeSp.EjecSP("CRE_ActDetalleBalGenEval_Sp", idEvalCred, nCajaInicial, xmlDetBalGenEval);
        }*/

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleEstResEvalAgrico_Sp", idEvalCred);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval)
        {
            return objEjeSp.EjecSP("CRE_ActDetalleEstResEvalAgrico_Sp", idEvalCred, xmlDetEstResEval);
        }

        /*public DataTable GrabarPropuestaDesembolso(int idSolicitud, int idEvalCred, int idCli, int idUsuario, string xmlPropDesembolso)
        {
            return objEjeSp.EjecSP("CRE_GrabarPropuestaDesembolso_SP", idSolicitud, idEvalCred, idCli, idUsuario, xmlPropDesembolso);
        }

        public DataTable ObtenerPropuestaDesembolso(int idSolicitud, int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ObtenerPropDesembolso_SP", idSolicitud, idEvalCred);
        }

        public DataTable ActualizarCondiCredito(int idSolicitud, int idEvalCred, int idTasa, decimal nTea, int idMoneda, decimal nMonto,int nPlazoCuota, int nCuotas, int idTipoPeriodo, int nPlazo)
        {
            return objEjeSp.EjecSP("CRE_ActualizarCondiCredito_SP", idSolicitud, idEvalCred, idTasa, nTea, idMoneda, nMonto, nPlazoCuota, nCuotas, idTipoPeriodo, nPlazo);
        }*/

        public DataSet ActualizarEvalCualit(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_ActualizarEvalCualitAgrop_Sp", idEvalCred);
        }
        public DataSet ADActualizarEvalCualitAgrico(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_ActualizarEvalCualitAgrico_Sp", idEvalCred);
        }
        public DataTable ADRetornaValidacionEntidades(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidaEntidadesEvaluacioAgri_SP", idCli);
        }

        public DataTable obtenerTiposSiembra()
        {
            return objEjeSp.EjecSP("CRE_ObtenerTiposSiembraEval_SP");
        }

        public DataTable obtenerUnidadesProductivas()
        {
            return objEjeSp.EjecSP("CRE_ObtenerUnidadesProductivasEval_SP");
        }

        public DataTable obtenerEtapasCultivo()
        {
            return objEjeSp.EjecSP("CRE_ObtenerEtapasCultivoEval_SP");
        }

        public DataTable obtenerActividadesPorEtapaCultivo(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_ObtenerActividadesPorEtapaCultivoEval_SP", parametros);
        }

        public DataTable obtenerUnidadesMedida()
        {
            return objEjeSp.EjecSP("CRE_ObtenerUnidadesMedidaEval_SP");
        }
        public DataTable ADRegistraOpRiesgos(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaCondicionesOpRiesgos_SP", idEvalCred);
        }
        public DataTable ADValidarVisitas(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidaVisitas_SP", idEvalCred);
        }

        public DataTable obtenerEvaluacionCultivos(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_ObtenerEvaluacionCultivos_SP", parametros);
        }
        public DataTable registrarEvaluacionCultivo(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_RegistrarEvaluacionCultivo_SP", parametros);
        }


        #region movimiento eval agricola


        public DataTable ADObtenerMovimientosEvalAgri(int idEvaluacionCultivo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerMovimientosEvalAgri_SP", idEvaluacionCultivo);
        }

        public DataTable ADRegistrarMovimientoEvalAgri(int idEvaluacionCultivo, string xml)
        {
            return objEjeSp.EjecSP("CRE_RegistrarMovimientoEvalAgri_SP", idEvaluacionCultivo, xml);
        }


        #endregion

        #region matriz agrícola
        public DataTable dtRegistroMatriz(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_ObtenerRegistrosMatriz_SP", parametros);
        }

        public DataTable dtRegistrarMatrizAgricola(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_RegistrarMatrizAgricola_SP", parametros);
        }

        public DataTable dtObtenerMatrizAgricola(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_ObtenerMatrizAgricola_SP", parametros);
        }

        public DataTable dtAlertaCultivo(params object[] parametros)
        {
            return objEjeSp.EjecSP("CRE_ObtenerAlertasCultivos_SP", parametros);
        }
        #endregion

    }
}
