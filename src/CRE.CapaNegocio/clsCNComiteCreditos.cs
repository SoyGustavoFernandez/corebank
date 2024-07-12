using System;
using System.Collections.Generic;
using System.Data;
using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNComiteCreditos
    {
        private clsADComiteCreditos objADComiteCreditos;

        public clsCNComiteCreditos()
        {
            this.objADComiteCreditos = new clsADComiteCreditos();
        }

        public clsRespuestaServidor CNGuardarComite(clsComiteCred objComite, int idPerfil)
        {
            return objADComiteCreditos.ADGuardarComite(objComite, idPerfil);
        }

        public clsRespuestaServidor CNIniciarComite(clsComiteCred objComite)
        {
            return objADComiteCreditos.ADIniciarComite(objComite, clsVarGlobal.User.idUsuario, clsVarGlobal.User.idEstablecimiento);
        }

        public clsDBResp CNActualizaComite(clsComiteCred objComite)
        {
            return objADComiteCreditos.ADActualizaComite(objComite);
        }

        public List<clsComiteCred> CNGetComitesCred(int idComite, int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return objADComiteCreditos.ADGetComitesCred(idComite, idAgencia, dFecIni, dFecFin);
        }

        public List<clsUsuComite> CNGetUsuComiteCred(clsComiteCred objComiteCred)
        {
            return objADComiteCreditos.ADGetUsuComiteCred(objComiteCred);
        }

        public List<clsEvalCredComite> CNGetEvalComiteCred(clsComiteCred objComiteCred)
        {
            return objADComiteCreditos.ADGetEvalComiteCred(objComiteCred);
        }

        public clsDBResp CNConfirmAsistUsuComite(int idComite, int idUsuConfirm, int idUsuario, DateTime dFecha)
        {
            return objADComiteCreditos.ADConfirmAsistUsuComite(idComite, idUsuConfirm, idUsuario, dFecha);
        }

        public clsDBResp CNAsigUsuResponsableEval(clsComiteCred objComite, clsEvalCredComite objEvalCred, clsDecisComite objUsuResponsable)
        {
            return objADComiteCreditos.ADAsigUsuResponsableEval(objComite, objEvalCred, objUsuResponsable);

        }

        public List<clsDecisComite> CNGetDeciComiteCred(clsEvalCredComite EvalCred)
        {
            return objADComiteCreditos.ADGetDeciComiteCred(EvalCred);
        }

        public clsDBResp CNActualizaDecisUsuComite(clsComiteCred objComite, clsEvalCredComite objEvalCred, clsDecisComite objDecision)
        {
            return objADComiteCreditos.ADActualizaDecisUsuComite(objComite, objEvalCred, objDecision);
        }

        public clsDBResp CNDecisionFinalEvalComite(clsEvalCredComite objEvalCred,clsCreditoProp objCreditoProp)
        {
            return objADComiteCreditos.ADDecisionFinalEvalComite(objEvalCred, objCreditoProp);
        }

        public clsDBResp CNFinalizaComite(clsComiteCred objComiteCred)
        {
            return objADComiteCreditos.ADFinalizaComite(objComiteCred);
        }

        public clsDBResp CNIniciarEvalComiteCred(clsEvalCredComite objEval)
        {
            return objADComiteCreditos.ADIniciarEvalComiteCred(objEval);
        }

        public DataTable CNListExcepcionesSolCre(int idSolicitud, int idTipOpe)
        {
            return objADComiteCreditos.ADListExcepcionesSolCre(idSolicitud, idTipOpe);
        }

        public DataSet CNLstGarantiasSolCre(int idSolicitud)
        {
            return objADComiteCreditos.ADLstGarantiasSolCre(idSolicitud);
        }

        public DataTable AsigResponsableRevisionCred(int idComiteCred,int idEvalCred, int idUsuario)
        {
            return objADComiteCreditos.AsigResponsableRevisionCred(idComiteCred,idEvalCred, idUsuario);
        }

        public DataTable CambiarOpinionUsuComiteCred(int idComiteCred, int idEvalCred, int idUsuario, bool lDecision, DateTime dFechaSistema)
        {
            return objADComiteCreditos.CambiarOpinionUsuComiteCred(idComiteCred,idEvalCred, idUsuario,lDecision,dFechaSistema);
        }

        public DataSet HistoricoEEFF(int idEvalCred)
        {
            return objADComiteCreditos.HistoricoEEFF(idEvalCred);
        }

        public List<clsComiteVirtual> listarBandejaComiteVirtual(int idUsuario)
        {
            return objADComiteCreditos.listarBandejaComiteVirtual(idUsuario);
        }

        public clsComiteVirtual grabarDecisionVirtual(int idUsuario, bool lConfirmAsis, int idComiteCred)
        {
            return objADComiteCreditos.grabarDecisionVirtual(idUsuario, lConfirmAsis, idComiteCred);
        }

        public List<clsUsuComite> obtenerParticipVirtual(int idComiteCred)
        {
            return objADComiteCreditos.obtenerParticipVirtual(idComiteCred);
        }

        public List<clsEvalCredComite> obtenerCreditoVirtual(int idComiteCred)
        {
            return objADComiteCreditos.obtenerCreditoVirtual(idComiteCred);
        }

        public string obtenerDatosComite(int idComiteCred)
        {
            return objADComiteCreditos.obtenerDatosComite(idComiteCred);
        }

        public DataTable obtenerDecisComiteVirtual()
        {
            return objADComiteCreditos.obtenerDecisComiteVirtual();
        }

        public List<clsDecisComite> listarParticipComiteCred(int idComiteCred, int idEval)
        {
            return objADComiteCreditos.listarParticipComiteCred(idComiteCred, idEval);
        }

        public DataTable guardarComentObsComiteVirtual(int idComiteCred, int idEvalCred, int idUsuario, string cComentario)
        {
            return objADComiteCreditos.guardarComentObsComiteVirtual(idComiteCred, idEvalCred, idUsuario, cComentario);
        }

        public DataTable obtenerComentObsComiteVirtual(int idComiteCred, int idEval, int idUsuario)
        {
            return objADComiteCreditos.obtenerComentObsComiteVirtual(idComiteCred, idEval, idUsuario);
        }

        public DataTable grabarEstadoEvalCred(int idEval, int idSolicitud, int idComiteCred, bool idEstado, bool lVigente)
        {
            return objADComiteCreditos.grabarEstadoEvalCred(idEval, idSolicitud, idComiteCred, idEstado, lVigente);
        }

        public string obtenerDatosEvalRevision(int idComiteCred)
        {
            return objADComiteCreditos.obtenerDatosEvalRevision(idComiteCred);
        }

        #region Sesion de Comite de Credito
        public clsComiteCreditoConfig obtenerComiteCreditoConfig()
        {
            DataSet dsComiteCredConfig = this.objADComiteCreditos.obtenerComiteCreditoConfig(clsVarGlobal.User.idEstablecimiento);
            clsComiteCreditoConfig objComiteCreditoConfig = new clsComiteCreditoConfig();
            if(dsComiteCredConfig.Tables.Count > 1)
            {
                objComiteCreditoConfig = (dsComiteCredConfig.Tables[0].Rows.Count > 0) ? dsComiteCredConfig.Tables[0].Rows[0].ToObject<clsComiteCreditoConfig>() :
                    new clsComiteCreditoConfig();

                objComiteCreditoConfig.lstComiteCreditoHorario = (dsComiteCredConfig.Tables[1].Rows.Count > 0)? dsComiteCredConfig.Tables[1].ToList<clsComiteCreditoHorario>() as List<clsComiteCreditoHorario>:
                new List<clsComiteCreditoHorario>();
            }

            return objComiteCreditoConfig;
        }

        public clsComiteCreditoSesion recuperarComiteCreditoSesion(int idComiteCred)
        {
            DataTable dtComiteCredSesion = this.objADComiteCreditos.recuperarComiteCreditoSesion(idComiteCred);
            return (dtComiteCredSesion.Rows.Count > 0) ?
                dtComiteCredSesion.Rows[0].ToObject<clsComiteCreditoSesion>() :
                new clsComiteCreditoSesion();
        }

        public DataTable obtenerComiteCreditoSesion(int idComiteCred, int idUsuario)
        {
            return this.objADComiteCreditos.obtenerComiteCreditoSesion(idComiteCred, idUsuario);
        }

        public DataTable grabarComiteCreditoSesion(int idComiteCred, clsComiteCreditoSesion objComiteCreditoSesion)
        {
            string xmlComiteCreditoSesion = string.Empty;

            List<clsComiteCreditoSesion> lstComiteCreditoSesion = new List<clsComiteCreditoSesion>();
            lstComiteCreditoSesion.Add(objComiteCreditoSesion);

            xmlComiteCreditoSesion = lstComiteCreditoSesion.ListObjectToXml<clsComiteCreditoSesion>("Sesion", "Sesiones");

            return this.objADComiteCreditos.grabarComiteCreditoSesion(idComiteCred, xmlComiteCreditoSesion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
        }
        public clsComiteCred obtenerComiteCred(int idComiteCred)
        {
            return this.objADComiteCreditos.obtenerComiteCred(idComiteCred);
        }
        public clsRespuestaServidor bloquearComiteCred(int idComiteCred)
        {
            DataTable dtRespuestaServidor = this.objADComiteCreditos.bloquearComiteCred(idComiteCred, clsVarGlobal.User.idUsuario);

            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        #endregion
    }
}
