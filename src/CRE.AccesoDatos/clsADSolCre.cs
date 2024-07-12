using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsADSolCre
    {
        IntConexion objCone;

        public clsADSolCre()
        {
            objCone = new clsGENEjeSP();
        }

        public clsADSolCre(bool lWebService)
        {
            objCone = new clsWCFEjeSP();
        }

        public clsCreditoProp GetCreditoPropSol(int idSolicitud)
        {
            DataTable dtData = objCone.EjecSP("CRE_RetornaCreditoPropSol_Sp", idSolicitud);
            return MapeaTablaEntidadCreditoProp(dtData);
        }

        public DataTable GetSolAprobDeneg(DateTime dFecIni, DateTime dFecFin)
        {
            return objCone.EjecSP("CRE_BuscarSolCredAprobDen_Sp", dFecIni, dFecFin);
        }

        private clsCreditoProp MapeaTablaEntidadCreditoProp(DataTable dtData)
        {
            clsCreditoProp objCreditoProp = new clsCreditoProp();
            foreach (DataRow row in dtData.Rows)
            {
                objCreditoProp.idOrigenCredProp = Convert.ToInt32(row["idOrigenCredProp"]);
                objCreditoProp.idSolicitud = Convert.ToInt32(row["idSolicitud"]);
                objCreditoProp.idSolAproba = Convert.ToInt32(row["idSolAproba"]);
                objCreditoProp.idNivelAprRanOpe = Convert.ToInt32(row["idNivelAprRanOpe"]);
                objCreditoProp.idCli = Convert.ToInt32(row["idCli"]);
                objCreditoProp.idActividad = Convert.ToInt32(row["idActividad"]);
                objCreditoProp.idActividadInterna = Convert.ToInt32(row["idActividadInterna"]);
                objCreditoProp.nMonto = Convert.ToDecimal(row["nMonto"]);
                objCreditoProp.idMoneda = Convert.ToInt32(row["idMoneda"]);
                objCreditoProp.cMoneda = Convert.ToString(row["cMoneda"]);
                objCreditoProp.nCuotas = Convert.ToInt32(row["nCuotas"]);
                objCreditoProp.idTipoPeriodo = Convert.ToInt32(row["idTipoPeriodo"]);
                objCreditoProp.cDescripTipoPeriodo = Convert.ToString(row["cDescripTipoPeriodo"]);
                objCreditoProp.nPlazoCuota = Convert.ToInt32(row["nPlazoCuota"]);
                objCreditoProp.nDiasGracia = Convert.ToInt32(row["nDiasGracia"]);
                objCreditoProp.dFechaDesembolso = Convert.ToDateTime(row["dFechaDesembolso"]);
                objCreditoProp.idTasa = Convert.ToInt32(row["idTasa"]);
                objCreditoProp.nTasaCompensatoria = Convert.ToDecimal(row["nTasaCompensatoria"]);
                objCreditoProp.cModalidadCredito = Convert.ToString(row["cModalidadCredito"]);
                objCreditoProp.cOperacion = Convert.ToString(row["cOperacion"]);
                objCreditoProp.idProducto = Convert.ToInt32(row["idProducto"]);
                objCreditoProp.cTipoCredito = Convert.ToString(row["cTipCred"]);
                objCreditoProp.cSubTipo = Convert.ToString(row["cSubTipCred"]);
                objCreditoProp.cTipoProducto = Convert.ToString(row["cProd"]);
                objCreditoProp.cSubProducto = Convert.ToString(row["cSubProd"]);
                objCreditoProp.cComentarios = Convert.ToString(row["cComentarios"]);
                objCreditoProp.nActivo = Convert.ToDecimal(row["nActivo"]);
                objCreditoProp.nPasivo = Convert.ToDecimal(row["nPasivo"]);
                objCreditoProp.nInventario = Convert.ToDecimal(row["nInventario"]);
                objCreditoProp.nPatrimonio = Convert.ToDecimal(row["nPatrimonio"]);
                objCreditoProp.nCostos = Convert.ToDecimal(row["nCostos"]);
                objCreditoProp.nDeudas = Convert.ToDecimal(row["nDeudas"]);
                objCreditoProp.nNeto = Convert.ToDecimal(row["nNeto"]);
                objCreditoProp.nDisponible = Convert.ToDecimal(row["nDisponible"]);
                objCreditoProp.nCuotaAprox = Convert.ToDecimal(row["nCuotaAprox"]);
                objCreditoProp.idAsesor = (DBNull.Value == row["idAsesor"])? 0 : Convert.ToInt32(row["idAsesor"]);
                objCreditoProp.idOperacion = Convert.ToInt32(row["idOperacion"]);
                objCreditoProp.idEvalCred = Convert.ToInt32(row["idEvalCred"]);
                objCreditoProp.nCuotasGracia = Convert.ToInt32(row["nCuotasGracia"]);
            }
            return objCreditoProp;
        }


        public clsDBResp GuardarCreditoProp(string xmlCreditoProp, int idUsuario, DateTime dFecha)
        {
            DataTable dtResult = objCone.EjecSP("CRE_GuardarCreditoPropSol_Sp", xmlCreditoProp, idUsuario, dFecha);
            return  new clsDBResp(dtResult);
        }

        public DataTable GetHistoricoPropuesta(int idSolicitud)
        {
            return objCone.EjecSP("CRE_GetHistoricoPropuesta_Sp", idSolicitud);
        }

        public DataTable GetSolAprobNiveles(int idUsuario, int idPerfil, DateTime dFecIni, DateTime dFecFin)
        {
            return objCone.EjecSP("CRE_LstSolCreAprobNiveles_Sp", idUsuario, idPerfil, dFecIni, dFecFin);
        }

        #region SolicitudCreditos

        public DataTable ADRegistrarSolicitudCredito(clsSolicitudCreditos objSol, int idUsuario, int idAgencia)
        {
            List<clsSolicitudCreditos> obj = new List<clsSolicitudCreditos>();
            obj.Add(objSol);

            return objCone.EjecSP("WCF_RegistroSolicitudCredito_SP", clsUtils.ListToXml<clsSolicitudCreditos>(obj), idUsuario, idAgencia);
        }

        public DataTable ADRegistroCreditoAmpliacion(int idSolicitud, int idCuenta, int idOperacion, decimal nSaldoCapital, decimal nSaldoInteres, decimal nSaldoMora, decimal nSaldoOtros, decimal nSaldoInteresCompensatorio)
        {
            return objCone.EjecSP("WCF_RegistrarCreditosAmpliacion_SP", idSolicitud, idCuenta, idOperacion, nSaldoCapital, nSaldoInteres, nSaldoMora, nSaldoOtros, nSaldoInteresCompensatorio);
        }

        public DataTable ADListaCampanaxCliente(int idTipoDocumento, string cDocumentoID, int idUsuario)
        {
            return objCone.EjecSP("WCF_ListarCampanaXCliente_SP", idTipoDocumento, cDocumentoID, idUsuario);
        }

        public DataSet ADBuscarSolicitudCred(int idTipoDocumento, string cDocumentoID)
        {
            return objCone.DSEjecSP("WCF_BuscaSolicitudCred_SP", idTipoDocumento, cDocumentoID);
        }

        public DataTable ADListaCreditosCliente(int idCli)
        {
            return objCone.EjecSP("WCF_ListaCuentasCliente_SP", idCli);
        }

        public DataTable ADListaProductoAgricolaCultivo()
        {
            return objCone.EjecSP("CRE_ListarCultivo_SP");
        }

        public DataTable ADListaProductoAgricolaCultivoVariedad(int idCultivoEval)
        {
            return objCone.EjecSP("CRE_ListarVariedadPorCultivo_SP", idCultivoEval);
        }

        public DataTable ADRegistroCultivoVariedadEvaluacion(int idEvalCred, int idCultivoEval, int idVariedadCultivoEval, int idAgencia)
        {
            return objCone.EjecSP("WCF_RegistroCultivoVariedadEvaluacion_SP", idEvalCred, idCultivoEval, idVariedadCultivoEval, idAgencia);
        }

        public DataTable ADProductoAgricolaCultivoVariedad(int idCultivoEval, int idSubProducto)
        {
            return objCone.EjecSP("WCF_ObtenerCultivoVariedadEvaluacion_SP", idCultivoEval, idSubProducto);
        }
        #endregion

        public DataTable ADObtenerAutorizacionPolizaPendientes()
        {
            return objCone.EjecSP("CRE_ObtenerAutorizacionPolizaPendientes_SP");
        }

        public DataTable ADRegistrarAutorizacionPoliza(params object[] parametros)
        {
            return objCone.EjecSP("CRE_RegistrarAutorizacionPoliza_SP", parametros);
        }

        public DataTable ADRegistrarDecisionAutorizacionPoliza(params object[] parametros)
        {
            return objCone.EjecSP("CRE_RegistrarDecisionAutorizacionPoliza_SP", parametros);
        }
    }
}
