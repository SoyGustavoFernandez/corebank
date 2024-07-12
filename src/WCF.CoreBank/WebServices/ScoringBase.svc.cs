using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.CoreBank.Interface;
using EntityLayer;
using CLI.Servicio;
using GEN.CapaNegocio;
using CRE.Servicio;
using System.Data;

namespace WCF.CoreBank.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScoringBase" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ScoringBase.svc or ScoringBase.svc.cs at the Solution Explorer and start debugging.
    public class ScoringBase : AbstractConexion, IScoringBase
    {
        private clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();
        private clsCNScoreCreditos objCN;

        public ScoringBase()
        {
            this.setConectionString();
        }

        #region WebServices

        public clsScoreEnt ScoreBase(string cToken, string cDNITitular, string cDNIConyuge)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            new clsCNVarGen().LisVar(datosToken.idAgencia);
            new clsCNVarApl().LisVar(datosToken.idAgencia); //revisar

            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cDNITitular, datosToken.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
            clsReniec obj = new clsReniec(objParam, objReniec);
            clsProcesaDatosRen objTitular = obj.GetReniec();

            if (objTitular == null)
            {
                return new clsScoreEnt();
            }

            if (!String.IsNullOrEmpty(cDNIConyuge))
            {
                objParam = null;
            }
            

            clsParamScore objParamScore = new clsParamScore();

            objParamScore.idAgencia = datosToken.idAgencia;
            objParamScore.idUsuario = datosToken.idUsuario;
            objParamScore.idSolicitud = 0;
            objParamScore.cNumDocuId = cDNITitular;
	        objParamScore.cNumDocuIdConyuge = cDNIConyuge;
	        objParamScore.cUbigeo = objTitular.cUbigeoDepNac+	objTitular.cUbigeoProvNac+ objTitular.cUbigeoDistNac;
            objParamScore.idTipoScore = 1;

            objCN = new clsCNScoreCreditos(true);
            
            DataTable dtResVal = objCN.CNValidarCondicionesBasicasScore(cDNITitular);
            if(Convert.ToInt32(dtResVal.Rows[0]["idResultado"]) == 0)
            {
                clsScoreEnt objEnt  = new clsScoreEnt();
                objEnt.lCumpleBasico = Convert.ToInt32(dtResVal.Rows[0]["idResultado"]);
                objEnt.cMensajeScore = dtResVal.Rows[0]["cMensaje"].ToString();
                objEnt.cScoreGrupoEvaluacion = dtResVal.Rows[0]["cEvalT"].ToString();
                return objEnt;
            }

            clsScore objScore = new clsScore(true);
            objScore.setObjParamScore(objParamScore);
            objScore.setIdTipoScore(objParamScore.idTipoScore);
            
            return objScore.ejecutarScore();
        }


        public clsScoreEnt Score(string cToken, string cDNITitular, string cDNIConyuge, int idDestino, int idTipoScore, int idSolicitud)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            new clsCNVarGen().LisVar(datosToken.idAgencia);
            new clsCNVarApl().LisVar(datosToken.idAgencia); //revisar

            clsParamScore objParamScore = new clsParamScore();

            objParamScore.idAgencia = datosToken.idAgencia;
            objParamScore.idUsuario = datosToken.idUsuario;
            objParamScore.idSolicitud = idSolicitud;
            objParamScore.cNumDocuId = cDNITitular;
            
            objParamScore.idTipoScore = idTipoScore;
            objParamScore.idDestino = idDestino;

            clsScore objScore = new clsScore(true);
            clsScoreEnt objRes;
            if(idSolicitud!=0)
            {
                
                objScore.setObjParamScore(objParamScore);
                objScore.setIdTipoScore(objParamScore.idTipoScore);
                objRes = objScore.ObtenerScoreSolicitud();
                if(objRes != null)
                {
                    return objRes;
                }
            }

            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(cDNITitular, datosToken.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
            clsReniec obj = new clsReniec(objParam, objReniec);
            clsProcesaDatosRen objTitular = obj.GetReniec();

            if (objTitular == null)
            {
                return new clsScoreEnt();
            }

            if (String.IsNullOrEmpty(cDNIConyuge))
            {
                cDNIConyuge = this.DevolverConyugeTitular(cDNITitular);
            }

            objParamScore.cNumDocuIdConyuge = cDNIConyuge;
            objParamScore.cUbigeo = objTitular.cUbigeoDepNac + objTitular.cUbigeoProvNac + objTitular.cUbigeoDistNac;

            objCN = new clsCNScoreCreditos(true);
            
            DataTable dtResVal = objCN.CNValidarCondicionesBasicasScore(cDNITitular);
            if(Convert.ToInt32(dtResVal.Rows[0]["idResultado"]) == 0)
            {
                clsScoreEnt objEnt  = new clsScoreEnt();
                objEnt.lCumpleBasico = Convert.ToInt32(dtResVal.Rows[0]["idResultado"]);
                objEnt.cMensajeScore = dtResVal.Rows[0]["cMensaje"].ToString();
                objEnt.cScoreGrupoEvaluacion =  dtResVal.Rows[0]["cEvalT"].ToString();
                objEnt.idScoreGrupoEvaluacion = Convert.ToInt32(dtResVal.Rows[0]["idScoreGrupoEvaluacion"]);
                return objEnt;
            }

            
            objScore.setObjParamScore(objParamScore);
            objScore.setIdTipoScore(objParamScore.idTipoScore);

            return objScore.ejecutarScore();
        }

        public string ValidarConyugeTitular(string cToken, string cDocumentoID)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            return DevolverConyugeTitular(cDocumentoID);
            
        }
        #endregion 

        #region Metodos privados
        
        private string DevolverConyugeTitular(string cDocumentoID)
        {
            objCN = new clsCNScoreCreditos(true);
            DataTable dt = objCN.CNObtenerConyugeCliente(cDocumentoID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["cDocumentoID"].ToString();
            }
            else
            {
                return "";
            }
        }

        
        #endregion 
    }
}
