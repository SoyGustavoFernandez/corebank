using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNEvalAgrico
    {
        private clsADEvalAgrico clsADEvalAgrico = new clsADEvalAgrico();

        public DataSet BuscarEvalCredito(int idEvalCred)
        {
            return this.clsADEvalAgrico.BuscarEvalCredito(idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlEvalCualit, string xmlReferencias, string xmlBalGenEval, string xmlEstResEval, string xmlDestCredProp, string xmlDetEstResEval, string xmlIndicadorEval)
        {
            return this.clsADEvalAgrico.ActualizarEval(idEvalCred, xmlEvalCred, xmlEvalCualit, xmlReferencias, xmlBalGenEval, xmlEstResEval, xmlDestCredProp, xmlDetEstResEval, xmlIndicadorEval);
        }

        public DataSet InicializarAgrico()
        {
            return this.clsADEvalAgrico.InicializarAgrico();
        }

        public DataSet RecuperarEvalCredito(int idEvalCred)
        {
            return this.clsADEvalAgrico.RecuperarEvalCredito(idEvalCred);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCredTemp, int lCanalAproCredEditable)
        {
            return this.clsADEvalAgrico.EnviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCredTemp, lCanalAproCredEditable);
        }

        public DataTable ActEstFinancieroslEval(int idEvalCred, string xmlBalGenEval, string xmlEstResEval)
        {
            return this.clsADEvalAgrico.ActEstFinancieroslEval(idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        /*public DataSet RecuperarDetalleBalGeneralEval(int idEvalCred)
        {
            return this.clsADEvalAgrico.RecuperarDetalleBalGeneralEval(idEvalCred);
        }

        public DataTable ActDetalleBalanceGeneralEval(int idEvalCred, decimal nCajaInicial, string xmlDetBalGenEval)
        {
            return this.clsADEvalAgrico.ActDetalleBalanceGeneralEval(idEvalCred, nCajaInicial, xmlDetBalGenEval);
        }*/

        public DataSet RecuperarDetalleEstResultadosEval(int idEvalCred)
        {
            return this.clsADEvalAgrico.RecuperarDetalleEstResultadosEval(idEvalCred);
        }

        public DataTable ActDetalleEstadosResultadoslEval(int idEvalCred, string xmlDetEstResEval)
        {
            return this.clsADEvalAgrico.ActDetalleEstadosResultadoslEval(idEvalCred, xmlDetEstResEval);
        }

        /*public DataTable GrabarPropuestaDesembolso(int idSolicitud, int idEvalCred, int idCli, int idUsuario, string xmlPropDesembolso)
        {
            return this.clsADEvalAgrico.GrabarPropuestaDesembolso(idSolicitud, idEvalCred, idCli, idUsuario, xmlPropDesembolso);
        }

        public DataTable ObtenerPropuestaDesembolso(int idSolicitud, int idEvalCred)
        {
            return this.clsADEvalAgrico.ObtenerPropuestaDesembolso(idSolicitud, idEvalCred);
        }

        public DataTable ActualizarCondiCredito(int idSolicitud, int idEvalCred, int idTasa, decimal nTea, int idMoneda, decimal nMonto, int nPlazoCuota, int nCuotas, int idTipoPeriodo, int nPlazo)
        {
            return this.clsADEvalAgrico.ActualizarCondiCredito( idSolicitud, idEvalCred, idTasa, nTea, idMoneda, nMonto, nPlazoCuota, nCuotas, idTipoPeriodo, nPlazo);
        }*/

        public List<clsEvalCualitativa> ActualizarEvalCualit(int idEvalCred)
        {
            List<clsEvalCualitativa> lstEvalCualitativo = new List<clsEvalCualitativa>();

            DataSet ds = this.clsADEvalAgrico.ActualizarEvalCualit(idEvalCred);
            DataTable dt = ds.Tables[0];

            if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
            {
                lstEvalCualitativo = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[1]) as List<clsEvalCualitativa>;
            }

            return lstEvalCualitativo;
        }

        public List<clsEvalCualitativa> CNActualizarEvalCualitAgrico(int idEvalCred)
        {
            List<clsEvalCualitativa> lstEvalCualitativo = new List<clsEvalCualitativa>();

            DataSet ds = this.clsADEvalAgrico.ADActualizarEvalCualitAgrico(idEvalCred);
            DataTable dt = ds.Tables[0];

            if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
            {
                lstEvalCualitativo = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[1]) as List<clsEvalCualitativa>;
            }

            return lstEvalCualitativo;
        }
        public DataTable CNRetornaValidacionEntidades(int idCli)
        {
            return this.clsADEvalAgrico.ADRetornaValidacionEntidades(idCli);
        }

        public DataTable obtenerTiposSiembra()
        {
            return this.clsADEvalAgrico.obtenerTiposSiembra();
        }

        public DataTable obtenerUnidadesProductivas()
        {
            return this.clsADEvalAgrico.obtenerUnidadesProductivas();
        }

        public DataTable obtenerEtapasCultivo()
        {
            return this.clsADEvalAgrico.obtenerEtapasCultivo();
        }

        public DataTable obtenerActividadesPorEtapaCultivo(int idEtapaCultivo)
        {
            return this.clsADEvalAgrico.obtenerActividadesPorEtapaCultivo(idEtapaCultivo);
        }

        public DataTable obtenerUnidadesMedida()
        {
            return this.clsADEvalAgrico.obtenerUnidadesMedida();
        }
        public DataTable CNRegistraOpRiesgos(int idEvalCred)
        {
            return this.clsADEvalAgrico.ADRegistraOpRiesgos(idEvalCred);
        }
        public DataTable CNValidarVisitas(int idEvalCred)
        {
            return this.clsADEvalAgrico.ADValidarVisitas(idEvalCred);
        }

        public List<clsEvaluacionCultivoAgrico> obtenerEvaluacionCultivos(int idEvalCred)
        {
            DataTable dt = clsADEvalAgrico.obtenerEvaluacionCultivos(idEvalCred);
            return dt.SoftToList<clsEvaluacionCultivoAgrico>().ToList<clsEvaluacionCultivoAgrico>();
        }
        public DataTable registrarEvaluacionCultivo(string cSql, clsEvaluacionCultivo objEvaluacionCultivo)
        {
            List<object> parametros = new List<object>();
            parametros.Add(objEvaluacionCultivo.idEvaluacionCultivo);
            parametros.Add(objEvaluacionCultivo.idCultivoEval);
            parametros.Add(objEvaluacionCultivo.idVariedadCultivoEval);
            parametros.Add(objEvaluacionCultivo.idZona);
            parametros.Add(objEvaluacionCultivo.idEvalCred);
            parametros.Add(objEvaluacionCultivo.nUniProdPropias);
            parametros.Add(objEvaluacionCultivo.nUniProdAlquiladas);
            parametros.Add(objEvaluacionCultivo.nUniProdPropiasFin);
            parametros.Add(objEvaluacionCultivo.nUniProdAlquiladasFin);
            parametros.Add(objEvaluacionCultivo.nMontoIngresos);
            parametros.Add(objEvaluacionCultivo.nMontoEgresos);
            parametros.Add(objEvaluacionCultivo.lVigente);            
            parametros.Add(objEvaluacionCultivo.idTipoSiembra);
            parametros.Add(objEvaluacionCultivo.idUnidadProductiva);
            parametros.Add(objEvaluacionCultivo.idUnidadMedida);
            parametros.Add(objEvaluacionCultivo.nUniProdPropiasAct);
            parametros.Add(objEvaluacionCultivo.nUniProdAlquiladasAct);
            parametros.Add(objEvaluacionCultivo.cCampanha);
        
            parametros.Add(cSql);
            if (objEvaluacionCultivo.idMatrizAgricola == null)
                parametros.Add(DBNull.Value);
            else
                parametros.Add(objEvaluacionCultivo.idMatrizAgricola);

            parametros.Add(objEvaluacionCultivo.idTipoCultivo);
            parametros.Add(objEvaluacionCultivo.idTipoFinanciamientoCultivo);

            return clsADEvalAgrico.registrarEvaluacionCultivo(parametros.ToArray());
        }

        #region Movimientos eval agricola


        public List<clsMovimientoEval> CNObtenerMovimientosEvalAgri(int idEvaluacionCultivo)
        {
            return this.clsADEvalAgrico.ADObtenerMovimientosEvalAgri(idEvaluacionCultivo).SoftToList<clsMovimientoEval>().ToList();
        }

        public DataTable CNRegistrarMovimientoEvalAgri(int idEvaluacionCultivo, List<clsMovimientoEval> lstMovimientosEval)
        {
            string xmlMovimientosEval = lstMovimientosEval.ListObjectToXml<clsMovimientoEval>("dtTabla", "dsTabla");
            return this.clsADEvalAgrico.ADRegistrarMovimientoEvalAgri(idEvaluacionCultivo, xmlMovimientosEval);
        }


        #endregion

        #region matriz agrícola
        public DataTable dtRegistroMatriz()
        {
            return this.clsADEvalAgrico.dtRegistroMatriz();
        }

        public DataTable dtRegistrarMatrizAgricola(string xmlMatrizAgricola, int idUsuario, int idAgencia, int idPerfil)
        {
            return this.clsADEvalAgrico.dtRegistrarMatrizAgricola(xmlMatrizAgricola, idUsuario, idAgencia, idPerfil);
        }

        public DataTable dtObtenerMatrizAgricola(clsMatrizAgricola objMatrizAgricola)
        {
            objMatrizAgricola.idAgencia = clsVarGlobal.nIdAgencia;
            return this.clsADEvalAgrico.dtObtenerMatrizAgricola(
                objMatrizAgricola.idMatrizAgricola,
                objMatrizAgricola.idAgencia,
                objMatrizAgricola.idCultivoEval,
                objMatrizAgricola.idVariedadCultivoEval,
                objMatrizAgricola.idTipoCultivo,
                objMatrizAgricola.idTipoFinanciamientoCultivo,
                objMatrizAgricola.idUnidadMedida,
                objMatrizAgricola.idUnidadProductiva
            );
        }

        public List<clsEvalCredAlertaVariable> lstAlertaCultivo(int idEvalCred, int idUsuario)
        {
            DataTable dt = this.clsADEvalAgrico.dtAlertaCultivo(idEvalCred, idUsuario);
            return dt.SoftToList<clsEvalCredAlertaVariable>().ToList<clsEvalCredAlertaVariable>();
        }
        #endregion

    }
}
