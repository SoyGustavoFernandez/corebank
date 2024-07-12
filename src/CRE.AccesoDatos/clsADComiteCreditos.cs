using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;
using GEN.AccesoDatos;
using EntityLayer;
using SolIntEls.GEN.Helper.Interface;

namespace CRE.AccesoDatos
{
    public class clsADComiteCreditos
    {
        public const int IdTipoOpeAprobCred = 55;

        public IntConexion objEjesp;
       
        public clsADComiteCreditos(bool lConexion)
        {
            objEjesp = new clsWCFEjeSP();
        }

        public clsADComiteCreditos()
        {
            objEjesp = new clsGENEjeSP();
        }

        public clsRespuestaServidor ADGuardarComite(clsComiteCred objComite, int idPerfil)
        {
            List<clsComiteCred> lstComiteCred = new List<clsComiteCred>();
            lstComiteCred.Add(objComite);
            string xmlComiteCred = lstComiteCred.GetXml<clsComiteCred>();

            DataTable dtRespuestaServidor = objEjesp.EjecSP("CRE_GuardarComiteCred_Sp", xmlComiteCred, idPerfil);

            return (dtRespuestaServidor.Rows.Count > 0)?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>():
                new clsRespuestaServidor();
        }

        public clsRespuestaServidor ADIniciarComite(clsComiteCred objComite, int idUsuario, int idEstablecimiento)
        {
            int idComiteCred = objComite.idComiteCred;
            int idUsuPreside = (int)objComite.idUsuPreside;
            int idPerfilPreside = (int)objComite.idPerfilPreside;
            DateTime dFecIni = (DateTime)objComite.dFecIni;

            DataSet dsSesionComite = objEjesp.DSEjecSP("CRE_IniciarComite_Sp", idComiteCred, idUsuPreside, idPerfilPreside, dFecIni, idUsuario, idEstablecimiento);

            clsRespuestaServidor objRespuestaServidor = (dsSesionComite.Tables[0].Rows.Count > 0)?
                dsSesionComite.Tables[0].Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();


            if (dsSesionComite.Tables.Count > 1)
            {
                objRespuestaServidor.objDatos = (dsSesionComite.Tables[1].Rows.Count > 0) ?
                    dsSesionComite.Tables[1].Rows[0].ToObject<clsComiteCreditoSesion>() :
                    new clsComiteCreditoSesion();
            }

            return objRespuestaServidor;
        }

        public clsDBResp ADActualizaComite(clsComiteCred objComite)
        {
            List<clsComiteCred> lstComiteCred = new List<clsComiteCred>();
            lstComiteCred.Add(objComite);
            string xmlComiteCred = lstComiteCred.GetXml<clsComiteCred>();

            clsDBResp objDbResp = new clsDBResp(objEjesp.EjecSP("CRE_ActualizaComiteCred_Sp", xmlComiteCred));

            return objDbResp;
        }

        public clsDBResp ADConfirmAsistUsuComite(int idComite, int idUsuConfirm, int idUsuario, DateTime dFecha)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_ConfirmarAsistComite_Sp", idComite, idUsuConfirm, idUsuario, dFecha);
            return new clsDBResp(dtResult);
        }

        public clsDBResp ADAsigUsuResponsableEval(clsComiteCred objComite, clsEvalCredComite objEvalCred, clsDecisComite objUsuResponsable)
        {
            int idComite = objComite.idComiteCred;
            int idEval = objEvalCred.idEval;
            int idUsuResponsable = objUsuResponsable.idUsuComite;
            int idUsuario = objComite.idUsuario;
            DateTime dFecha = objComite.dFecha.Date;
            clsDBResp objDbResp = new clsDBResp(objEjesp.EjecSP("CRE_AsigUsuResponsableEval_Sp", idComite, idEval, idUsuResponsable, idUsuario, dFecha));
            if (objDbResp.nMsje == 0)
            {
                objComite.lstEvalCred = ADGetEvalComiteCred(objComite);
            }

            return objDbResp;
        }

        public clsDBResp ADActualizaDecisUsuComite(clsComiteCred objComite, clsEvalCredComite objEvalCred, clsDecisComite objDecision)
        {
            int idComite = objComite.idComiteCred;
            int idEval = objEvalCred.idEval;
            int idUsuComite = objDecision.idUsuComite;
            DateTime dFecha = objComite.dFecha.Date;
            DataTable dtResult = objEjesp.EjecSP("CRE_ActualizaDecisUsuComite_Sp", idComite, idEval, idUsuComite, dFecha);
            return new clsDBResp(dtResult);
        }

        public clsDBResp ADFinalizaComite(clsComiteCred objComiteCred)
        {
            int idComite = objComiteCred.idComiteCred;
            int idUsuComite = objComiteCred.idUsuario;
            DateTime dFecha = objComiteCred.dFecha.Date;
            DataTable dtResult = objEjesp.EjecSP("CRE_FinalizarComite_Sp", idComite, dFecha, idUsuComite);
            return new clsDBResp(dtResult);
        }

        public clsDBResp ADDecisionFinalEvalComite(clsEvalCredComite objEvalCred, clsCreditoProp objCreditoProp)
        {
            int idComite = objEvalCred.ComiteCred.idComiteCred;
            string xmlEvalCred = objEvalCred.GetXml();
            string xmlObservaciones = objEvalCred.lstObservaciones.GetXml<clsObservacion>();
            string xmlCreditoProp = objCreditoProp.GetXml();

            DateTime dFecha = objEvalCred.ComiteCred.dFecha.Date;
            int idUsuario = objEvalCred.ComiteCred.idUsuario;
            DataTable dtResult = objEjesp.EjecSP("CRE_DecisionFinalEvalComite_Sp", idComite, xmlEvalCred, xmlObservaciones, xmlCreditoProp,
                                                                                    dFecha, idUsuario);
            return new clsDBResp(dtResult);
        }

        public List<clsComiteCred> ADGetComitesCred(int idComite, int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstComitesCred_Sp", idComite, idAgencia, dFecIni, dFecFin);
            List<clsComiteCred> lstComites = MapeaTablaEntidadComite(dtResult);
            return lstComites;
        }

        public List<clsUsuComite> ADGetUsuComiteCred(clsComiteCred objComiteCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstUsuComiteCred_Sp", objComiteCred.idComiteCred);
            return MapeaTablaEntidadUsuario(dtResult, objComiteCred);
        }

        public List<clsEvalCredComite> ADGetEvalComiteCred(clsComiteCred objComiteCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstEvalComiteCred_Sp", objComiteCred.idComiteCred, clsVarGlobal.PerfilUsu.idPerfil);
            return MapeaTablaEntidadEvalCred(dtResult, objComiteCred);
        }

        public List<clsDecisComite> ADGetDeciComiteCred(clsEvalCredComite EvalCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstDeciComiteCred_Sp", EvalCred.ComiteCred.idComiteCred, EvalCred.idEval);
            return MapeaTablaEntidadDecisComite(dtResult);
        }

        public List<clsDecisComite> ObtenerDecisUsuComiteCred(int idComiteCred, int idEvalCred)
        {
            DataTable dtRes = objEjesp.EjecSP("CRE_ObtenerDecisUsuComiteCred_SP",idComiteCred,idEvalCred);
            return DataTableToList.ConvertTo<clsDecisComite>(dtRes) as List<clsDecisComite>;
        }

        private List<clsComiteCred> MapeaTablaEntidadComite(DataTable dtResult)
        {
            List<clsComiteCred> lstComites = new List<clsComiteCred>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsComiteCred objComite = new clsComiteCred()
                {
                    idComiteCred = Convert.ToInt32(row["idComiteCred"]),
                    cNomComite = Convert.ToString(row["cNomComite"]),
                    cDescComite = Convert.ToString(row["cDescComite"]),
                    idAgencia = Convert.ToInt32(row["idAgencia"]),
                    cNombreAge = Convert.ToString(row["cNombreAge"]),
                    idEstado = Convert.ToInt32(row["idEstado"]),
                    cEstComiteCred = Convert.ToString(row["cEstComiteCred"]),
                    idUsuarioReg = Convert.ToInt32(row["idUsuReg"]),
                    idUsuario = Convert.ToInt32(row["idUsuReg"]),
                    cWinUser = Convert.ToString(row["cWinUser"]),
                    idUsuPreside = row["idUsuPreside"] != DBNull.Value ? Convert.ToInt32(row["idUsuPreside"]) : (int?)null,
                    cWinUserPreside = Convert.ToString(row["cWinUserPreside"]),
                    idPerfilPreside = row["idPerfilPreside"] != DBNull.Value ? Convert.ToInt32(row["idPerfilPreside"]) : (int?)null,
                    dFecha = Convert.ToDateTime(row["dFecReg"]),
                    dFecIni = row["dFecIni"] != DBNull.Value ? Convert.ToDateTime(row["dFecIni"]) : (DateTime?)null,
                    dFecFin = row["dFecFin"] != DBNull.Value ? Convert.ToDateTime(row["dFecFin"]) : (DateTime?)null,
                    nDuracion = Convert.ToInt32(row["nDuracion"]),
                    lVigente = Convert.ToBoolean(row["lVigente"]),
                    idTipoComiteCred = Convert.ToInt32(row["idTipoComiteCred"])
                };
                //objComite.lstParticipantes = ADGetUsuComiteCred(objComite);
                //objComite.lstEvalCred = ADGetEvalComiteCred(objComite);
                lstComites.Add(objComite);
            }
            return lstComites;
        }

        private List<clsUsuComite> MapeaTablaEntidadUsuario(DataTable dtResult, clsComiteCred objComiteCred)
        {
            List<clsUsuComite> lstUsuarios = new List<clsUsuComite>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsUsuComite objUsuario = new clsUsuComite()
                {
                    ComiteCred = objComiteCred,
                    idComiteCred = Convert.ToInt32(row["idComiteCred"]),
                    idUsuario = Convert.ToInt32(row["idUsuario"]),
                    cNombre = Convert.ToString(row["cNombre"]),
                    cWinUser = Convert.ToString(row["cWinUser"]),
                    lConfirmAsis = Convert.ToBoolean(row["lConfirmAsis"]),
                    lPresideComite = Convert.ToBoolean(row["lPresideComite"]),
                    idTipoParticip = Convert.ToInt32(row["idTipoParticip"]),
                    cTipoParticip = Convert.ToString(row["cTipoParticip"]),
                    idCargo = Convert.ToInt32(row["idCargo"]),
                    lAutenticacionBiometrica = Convert.ToBoolean(row["lAutenticacionBiometrica"]),
                    lInvitacion = Convert.ToBoolean(row["lInvitacion"])
                };
                lstUsuarios.Add(objUsuario);
            }
            return lstUsuarios;
        }

        private List<clsEvalCredComite> MapeaTablaEntidadEvalCred(DataTable dtResult, clsComiteCred objComiteCred)
        {
            List<clsEvalCredComite> lstEvalCred = new List<clsEvalCredComite>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsEvalCredComite objEvalCred = new clsEvalCredComite()
                {
                    ComiteCred = objComiteCred,
                    idEvalComiteCred = Convert.ToInt32(row["idEvalComiteCred"]),
                    idEval = Convert.ToInt32(row["idEval"]),
                    idSolicitud = Convert.ToInt32(row["idSolicitud"]),
                    idTipEval = Convert.ToInt32(row["idTipEval"]),
                    nMontoProp = Convert.ToDecimal(row["nMontoProp"]),
                    nMontoSoli = Convert.ToDecimal(row["nMontoSoli"]),
                    idUsuResponsable = row["idUsuResponsable"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idUsuResponsable"]),
                    idResultado = row["idResultado"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idResultado"]),
                    cResultado = Convert.ToString(row["cResultado"]),
                    idProducto = Convert.ToInt32(row["idProducto"]),
                    cProducto = Convert.ToString(row["cProducto"]),
                    cDocumentoID = Convert.ToString(row["cDocumentoID"]),
                    cNombre = Convert.ToString(row["cNombre"]),
                    idCli = Convert.ToInt32(row["idCli"]),
                    idMoneda = Convert.ToInt32(row["idMoneda"]),
                    cMoneda = Convert.ToString(row["cMoneda"]),
                    idAsesor = row["idAsesor"] == DBNull.Value ? 0 : Convert.ToInt32(row["idAsesor"]),
                    cAsesor = Convert.ToString(row["cAsesor"]),
                    idModalidadCredito = Convert.ToInt32(row["idModalidadCredito"]),
                    cModalidadCredito = Convert.ToString(row["cModalidadCredito"]),
                    idOperacion = Convert.ToInt32(row["idOperacion"]),
                    cOperacion = Convert.ToString(row["cOperacion"]),

                    idNivelAprobacion = (row["idNivelAprobacion"] == DBNull.Value ? 0 : Convert.ToInt32(row["idNivelAprobacion"])),
                    idEtapaEvalCred = (row["idEtapaEvalCred"] == DBNull.Value ? 0 : Convert.ToInt32(row["idEtapaEvalCred"])),
                    cEtapa = Convert.ToString(row["cEtapa"]),
                    idEstadoEvalCred = (row["idEstadoEvalCred"] == DBNull.Value ? 0 : Convert.ToInt32(row["idEstadoEvalCred"])),
                    cEstado = Convert.ToString(row["cEstado"]),
                    idMotRechazo = (row["idMotRechazo"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idMotRechazo"])),
                    cComentario = Convert.ToString(row["cComentario"]),
                    cComentRev = Convert.ToString(row["cComentRev"]),
                    cNombreResponsable = Convert.ToString(row["cNombreResponsable"]),
                };

                objEvalCred.lstDecisComite = ObtenerDecisUsuComiteCred(objComiteCred.idComiteCred,objEvalCred.idEval);
                //objEvalCred.lstObservaciones = new clsADObservaciones().ADGetObservaciones(objEvalCred.idSolicitud, IdTipoOpeAprobCred);
                objEvalCred.lstObsAprobador = new clsADObservacionAprobador().ListarObsAprobador(objEvalCred.idEval);
                lstEvalCred.Add(objEvalCred);
            }
            return lstEvalCred;
        }

        private List<clsDecisComite> MapeaTablaEntidadDecisComite(DataTable dtResult)
        {
            List<clsDecisComite> lstDecisiones = new List<clsDecisComite>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDecisComite objDecision = new clsDecisComite()
                {
                    lResponsable = false,
                    idUsuComite = Convert.ToInt32(row["idUsuComite"]),
                    cNombre = Convert.ToString(row["cNombre"]),
                    lDecision = Convert.ToBoolean(row["lDecision"]),
                    cWinUser = Convert.ToString(row["cWinUser"])
                };
                lstDecisiones.Add(objDecision);
            }
            return lstDecisiones;
        }

        private List<clsComiteVirtual> MapeaTablaBandejaComiteVirtual(DataTable dtResult)
        {
            List<clsComiteVirtual> lstComiteVirtual = new List<clsComiteVirtual>();
            foreach (DataRow row in dtResult.Rows)
            {
                string cConfirmarAsistencia = "";
                if ((bool)row["lInvitacion"] == true) 
                {
                    cConfirmarAsistencia = "Pendiente";
                }
                else if ((bool)row["lInvitacion"] == false)
                {
                    if ((bool)row["lConfirmAsis"] == true)
                    {
                        cConfirmarAsistencia = "Aceptado";
                    }
                    else if ((bool)row["lConfirmAsis"] == false)
                    {
                        cConfirmarAsistencia = "Rechazado";
                    }
                }
                clsComiteVirtual objComiteVirtual = new clsComiteVirtual()
                {
                    idComiteCred = Convert.ToInt32(row["idComiteCred"]),
                    cDesZona = Convert.ToString(row["cDesZona"]),
                    cNomCorto = Convert.ToString(row["cNomCorto"]),
                    cNomComite = Convert.ToString(row["cNomComite"]),
                    nParticipantes = Convert.ToInt32(row["nParticipantes"]),
                    nEvaluaciones = Convert.ToInt32(row["nEvaluaciones"]),
                    lConfirmAsis = Convert.ToBoolean(row["lConfirmAsis"]),
                    lInvitacion = Convert.ToBoolean(row["lInvitacion"]),
                    cAsistencia = cConfirmarAsistencia.ToString(),
                };
                lstComiteVirtual.Add(objComiteVirtual);
            }
            return lstComiteVirtual;

        }

        public clsDBResp ADIniciarEvalComiteCred(clsEvalCredComite objEval)
        {
            int idComite = objEval.ComiteCred.idComiteCred;
            int idEval = objEval.idEval;
            DateTime dFecha = objEval.ComiteCred.dFecha.Date;
            int idUsuario = objEval.ComiteCred.idUsuario;
            DataTable dtResult = objEjesp.EjecSP("CRE_IniciarEvalComiteCred_Sp", idComite, idEval, dFecha, idUsuario);
            return new clsDBResp(dtResult);
        }

        public DataTable ADListExcepcionesSolCre(int idSolicitud, int idTipOpe)
        {
            return objEjesp.EjecSP("CRE_ListExcepcionesSolCre_Sp", idSolicitud, idTipOpe);
        }

        public DataSet ADLstGarantiasSolCre(int idSolicitud)
        {
            return objEjesp.DSEjecSP("CRE_LstDetGarantiaSolCre_Sp", idSolicitud);
        }

        public DataTable AsigResponsableRevisionCred(int idComiteCred,int idEvalCred, int idUsuario)
        {
            return objEjesp.EjecSP("CRE_AsigResponsableRevisionCred_SP", idComiteCred,idEvalCred, idUsuario);
        }

        public DataTable CambiarOpinionUsuComiteCred(int idComiteCred,int idEvalCred, int idUsuario, bool lDecision, DateTime dFechaSistema)
        {
            return objEjesp.EjecSP("CRE_CambiarOpinionUsuComiteCred_SP", idComiteCred,idEvalCred, idUsuario,lDecision,dFechaSistema);
        }

        public DataSet HistoricoEEFF(int idEvalCred)
        {
            return objEjesp.DSEjecSP("RPT_HistoricoEEFF_Sp", idEvalCred);
        }

        public List<clsComiteVirtual> listarBandejaComiteVirtual(int idUsuario)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_ListarComiteVirtual_SP", idUsuario);
            return MapeaTablaBandejaComiteVirtual(dtResult);
        }

        public clsComiteVirtual grabarDecisionVirtual(int idUsuario, bool lConfirmAsis, int idComiteCred)
        {
            DataTable dtDecisionVirtual = objEjesp.EjecSP("CRE_GrabarDecisionVirtual_SP", idUsuario, lConfirmAsis, idComiteCred);

            return (dtDecisionVirtual.Rows.Count > 0) ?
                dtDecisionVirtual.Rows[0].ToObject<clsComiteVirtual>() :
                new clsComiteVirtual();
        }

        public List<clsUsuComite> obtenerParticipVirtual(int idComiteCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstUsuComiteCred_Sp", idComiteCred);
            return (dtResult.Rows.Count > 0) ?
                dtResult.ToList<clsUsuComite>() as List<clsUsuComite> :
                new List<clsUsuComite>();
        }

        public List<clsEvalCredComite> obtenerCreditoVirtual(int idComiteCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_LstEvalComiteCred_Sp", idComiteCred, clsVarGlobal.PerfilUsu.idPerfil);
            return (dtResult.Rows.Count > 0) ?
                dtResult.ToList<clsEvalCredComite>() as List<clsEvalCredComite> :
                new List<clsEvalCredComite>();
        }

        public string obtenerDatosComite(int idComiteCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_ListarDatosComite_SP", idComiteCred);
            return (dtResult.Rows.Count > 0) ?  dtResult.Rows[0][0].ToString() : "";
        }

        public DataTable obtenerDecisComiteVirtual()
        {
            return objEjesp.EjecSP("CRE_ListarDecisComiteVirtual_SP"); 
        }

        public List<clsDecisComite> listarParticipComiteCred(int idComiteCred, int idEval)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_ListarParticipComiteCred_SP", idComiteCred, idEval);
            return (dtResult.Rows.Count > 0) ?
                dtResult.ToList<clsDecisComite>() as List<clsDecisComite> :
                new List<clsDecisComite>();
        }

        public DataTable guardarComentObsComiteVirtual(int idComiteCred, int idEvalCred, int idUsuario, string cComentario)
        {
            return objEjesp.EjecSP("CRE_GuardarComentObsComiteVirtual_SP", idComiteCred, idEvalCred, idUsuario, cComentario);
        }

        public DataTable obtenerComentObsComiteVirtual(int idComiteCred, int idEval, int idUsuario)
        {
            return objEjesp.EjecSP("CRE_ObtenerComentObsComiteVirtual_SP", idComiteCred, idEval, idUsuario);
        }

        public DataTable grabarEstadoEvalCred(int idEval, int idSolicitud, int idComiteCred, bool idEstado, bool lVigente)
        {
            return objEjesp.EjecSP("CRE_GrabarEstadoEvalCred_SP", idEval, idSolicitud, idComiteCred, idEstado, lVigente);
        }

        public string obtenerDatosEvalRevision(int idComiteCred)
        {
            DataTable dtResult = objEjesp.EjecSP("CRE_ObtenerDatosEvalRevision_SP", idComiteCred);
            return (dtResult.Rows.Count > 0) ? dtResult.Rows[0][0].ToString() : "";
        }

        #region Sesion de Comite de Credito
        public DataSet obtenerComiteCreditoConfig(int idEstablecimiento)
        {
            return objEjesp.DSEjecSP("CRE_ObtenerComiteCreditoConfig_SP", idEstablecimiento);
        }

        public DataTable recuperarComiteCreditoSesion(int idComiteCred)
        {
            return objEjesp.EjecSP("CRE_RecuperarComiteCreditoSesion_SP", idComiteCred);
        }
        public DataTable obtenerComiteCreditoSesion(int idComiteCred, int idUsuario)
        {
            return objEjesp.EjecSP("CRE_ObtenerComiteCreditoSesion_SP", idComiteCred, idUsuario);
        }

        public DataTable grabarComiteCreditoSesion(int idComiteCred, string xmlComiteCreditoSesion, int idUsuario, DateTime dFechaSistema)
        {
            return objEjesp.EjecSP("CRE_GrabarComiteCreditoSesion_SP",idComiteCred, xmlComiteCreditoSesion, idUsuario, dFechaSistema);
        }

        public clsComiteCred obtenerComiteCred(int idComiteCred)
        {
            DataSet dsComiteCred = this.objEjesp.DSEjecSP("CRE_ObtenerComiteCred_SP", idComiteCred);

            clsComiteCred objComiteCred = (dsComiteCred.Tables[0].Rows.Count > 0) ?
                dsComiteCred.Tables[0].Rows[0].ToObject<clsComiteCred>() :
                new clsComiteCred();

            if (dsComiteCred.Tables.Count > 1)
            {
                objComiteCred.lstEvalCred = (dsComiteCred.Tables[1].Rows.Count > 0) ?
                    dsComiteCred.Tables[1].ToList<clsEvalCredComite>() as List<clsEvalCredComite>:
                    new List<clsEvalCredComite>();
            }

            return objComiteCred;
        }
        public DataTable bloquearComiteCred(int idComiteCred, int idUsuario)
        {
            return this.objEjesp.EjecSP("CRE_BloquearComiteCred_SP", idComiteCred, idUsuario);
        }
        #endregion
    }
}
