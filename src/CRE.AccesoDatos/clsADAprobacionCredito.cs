using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsADAprobacionCredito
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable GestionarAprobacion(int idSolicitud, int idEvalCred, int idAgencia, decimal nMonto, int idPerfil, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GestionarAprobacion_SP", idSolicitud, idEvalCred, idAgencia, nMonto, idPerfil, idUsuario);
        }

        public DataTable NroExcepcionesCredito(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_NroExcepcionesCreditos_SP", idSolicitud);
        }

        public DataTable NroExcepcionesCreditoGrupoSolidario(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_NroExcepcionesCreditosGrupales_SP", idSolicitudCredGrupoSol);
        }
        public DataTable GuardarGestionAprobacion(int idSolicitud, int idEvalCred, int idUsuario,int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision)
        {
            return objEjeSp.EjecSP("CRE_GuardarGestionAprobacion_SP", idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision);
        }

        public DataTable GuardarDecisionComite(int idEvalComiteCred, int idSolicitud, int idEvalCred, int idUsuario,int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision,
            string cComentario, string cComentRev,bool lVerificacion, int idMotRechazo)
        {
            return objEjeSp.EjecSP("CRE_GuardarDecisionComite_SP", idEvalComiteCred, idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision,
                cComentario,cComentRev,lVerificacion,idMotRechazo);
        }


        public DataTable GuardarDecisionAprobador(int idSolicitud, int idEvalCred, int idUsuario,int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision,
            string cComentario, bool lVerificacion, int idMotRechazo, DateTime idFechaFin)
        {
            return objEjeSp.EjecSP("CRE_GuardarDecisionAprobador_SP", idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision,
                cComentario,lVerificacion,idMotRechazo,idFechaFin, 1/*por el corebank*/);
        }

        public DataTable GuardarDecisionAprobadorGrupal(int idSolicitudCredGrupoSol, int idEvalCredGrupoSol, string xmlEvalCredIntegGrupoSol, int idUsuario, int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision,
            string cComentario, bool lVerificacion, int idMotRechazo, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CRE_GuardarDecisionAprobadorGrupal_SP", idSolicitudCredGrupoSol, idEvalCredGrupoSol, xmlEvalCredIntegGrupoSol, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision,
                cComentario, lVerificacion, idMotRechazo, dFechaFin);
        }
        public DataTable ActualizarCondicionesCredito(int idEvalCred,int idSolicitud, decimal nMonto, int nCuotas, int idTipoPeriodo, int nPlazoCuota, int nPlazo, int nCuotasGracia, int nDiasGracia, DateTime dFechaDesemProp, int idProducto, int idTasa, decimal nTasa)
        {
            return objEjeSp.EjecSP("CRE_ActualizarCondicionesCredito_SP",idEvalCred,idSolicitud,nMonto,nCuotas,idTipoPeriodo,nPlazoCuota,nPlazo,nCuotasGracia,nDiasGracia,dFechaDesemProp,idProducto,idTasa,nTasa);
        }

        public clsCreditoProp ObtenerCondicionesCredito(int idEvalCred)
        {
            DataTable dtRes=objEjeSp.EjecSP("CRE_ObtenerCondicionesCredito_SP",idEvalCred);

            if (dtRes.Rows.Count <= 0)
                return new clsCreditoProp();

            return (new clsCreditoProp()
            {
                idEvalCred = Convert.ToInt32(dtRes.Rows[0]["idEvalCred"]),
                idSolicitud = Convert.ToInt32(dtRes.Rows[0]["idSolicitud"]),
                nMonto = Convert.ToDecimal(dtRes.Rows[0]["nCapitalPropuesto"]),
                nCuotas = Convert.ToInt32(dtRes.Rows[0]["nCuotas"]),
                idTipoPeriodo = Convert.ToInt32(dtRes.Rows[0]["idTipoPeriodo"]),
                nPlazoCuota = Convert.ToInt32(dtRes.Rows[0]["nPlazoCuota"]),
                nPlazo = Convert.ToInt32(dtRes.Rows[0]["nPlazo"]),
                nCuotasGracia = Convert.ToInt32(dtRes.Rows[0]["nCuotasGracia"]),
                nDiasGracia = Convert.ToInt32(dtRes.Rows[0]["ndiasgracia"]),
                dFechaDesembolso = Convert.ToDateTime(dtRes.Rows[0]["dFechaDesembolso"]),
                idProducto = Convert.ToInt32(dtRes.Rows[0]["idProducto"]),
                idTasa = Convert.ToInt32(dtRes.Rows[0]["idTasa"]),
                nTasaCompensatoria = Convert.ToDecimal(dtRes.Rows[0]["nTEA"]),
                idSubProducto = Convert.ToInt32(dtRes.Rows[0]["idSubProducto"]),
                idOperacion = Convert.ToInt32(dtRes.Rows[0]["idOperacion"]),
                idAgencia = Convert.ToInt32(dtRes.Rows[0]["idAgencia"]),
                idCli = Convert.ToInt32(dtRes.Rows[0]["idCli"]),
                idClasificacionInterna = Convert.ToInt32(dtRes.Rows[0]["idClasificacionInterna"])
            });
        }

        public clsAprobacionEvalCred InicializarAprobacionEvalCred(int idEvalCred, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            DataSet dsRes = objEjeSp.DSEjecSP("CRE_InicializarAprobacionEvalCred_SP",idEvalCred,idUsuario,idPerfil,dFechaSistema);

            if (Convert.ToInt32(dsRes.Tables[0].Rows[0]["idError"]) == 0)
            {
                List<clsAprobacionEvalCred> objAproEvalCred = DataTableToList.ConvertTo<clsAprobacionEvalCred>(dsRes.Tables[1]) as List<clsAprobacionEvalCred>;

                if (objAproEvalCred.Count > 0)
                {
                    objAproEvalCred[0].lstObsAprobador = new clsADObservacionAprobador().ListarObsAprobador(idEvalCred);
                    return objAproEvalCred[0];
                }
            }
            return null;
        }

        public clsAproEvalCredGrupoSol IniciaAprobacionEvalCredGrupal(int idEvalCredGrupoSol, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            DataSet dsRes = objEjeSp.DSEjecSP("CRE_IniciaAprobacionEvalCredGrupal_SP", idEvalCredGrupoSol, idUsuario, idPerfil, dFechaSistema);

            if (Convert.ToInt32(dsRes.Tables[0].Rows[0]["idError"]) == 0 && dsRes.Tables[1].Rows.Count>0)
            {
                List<clsAproEvalCredGrupoSol> objAproEvalCred = DataTableToList.ConvertTo<clsAproEvalCredGrupoSol>(dsRes.Tables[1]) as List<clsAproEvalCredGrupoSol>;

                if (objAproEvalCred.Count > 0)
                {
                    objAproEvalCred[0].lstObsAprobadorGrupoSol = new clsADObservacionAprobador().ListaObsAprobadorGrupoSol(idEvalCredGrupoSol);
                    return objAproEvalCred[0];
                }
            }
            return null;
        }

        public clsRevisionEvalCred InicializarRevisionEvalCred(int idEvalCred, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {

            DataSet dsRes = objEjeSp.DSEjecSP("CRE_InicializarRevisionEvalCred_SP", idEvalCred, idUsuario, idPerfil, dFechaSistema);

            if (Convert.ToInt32(dsRes.Tables[0].Rows[0]["idError"]) == 0)
            {
                List<clsRevisionEvalCred> objRevEvalCred = DataTableToList.ConvertTo<clsRevisionEvalCred>(dsRes.Tables[1]) as List<clsRevisionEvalCred>;

                if (objRevEvalCred.Count > 0)
                {
                    objRevEvalCred[0].lstObsAprobador = new clsADObservacionAprobador().ListarObsAprobador(idEvalCred);
                    return objRevEvalCred[0];
                }
            }
            return null;
        }

        public DataTable GuardarDecisionRevisor(int idSolicitud, int idEvalCred, int idUsuario, int idEstadoEvalCred, int idNivelAproSig, string cComentario, bool lVerificacion, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CRE_GuardarDecisionRevisor_SP", idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idNivelAproSig, cComentario, lVerificacion, dFechaFin);
        }

        public DataTable GestionarAprobacionGrupal(int idSolicitudCredGrupoSol, int idEvalCredGrupoSol, int idAgencia, decimal nMonto)
        {
            return objEjeSp.EjecSP("CRE_GestionarAprobacionGrupal_SP", idSolicitudCredGrupoSol, idEvalCredGrupoSol, idAgencia, nMonto);
        }
        public DataTable ActaCreditoGrupoSol(int idGrupo, int idSolicitudGrupo)
        {
            return objEjeSp.EjecSP("CRE_ReporteSolicitudSolidarioPart1_SP", idGrupo, idSolicitudGrupo);
        }
        public DataTable ActaCreditoGrupoSol2(int idGrupo, int idSolicitudGrupo)
        {
            return objEjeSp.EjecSP("CRE_ActaResCredSolidarioPart2_SP", idGrupo, idSolicitudGrupo);
        }
        public DataTable ActaCreditoGrupoSol3(int idGrupo, int idSolicitudGrupo)
        {
            return objEjeSp.EjecSP("CRE_ActaResCredSolidarioPart3_SP", idGrupo, idSolicitudGrupo);
        }
        public DataTable ActaCreditoGrupoSol4(int idGrupo, int idSolicitudGrupo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosExcepcionGS_SP", idGrupo, idSolicitudGrupo);
        }
        public DataTable LisNivelAprobaSolCredGrupoSol(int idSolicitudGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_LisNivelAprobaSolCredGrupoSol_SP", idSolicitudGrupoSol);
        }
        public DataTable ADDeterUsuPuedeAprobaEval(int idUsuario, int idPerfil, int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_DeterUsuPuedeAprobaEval_SP", idUsuario, idPerfil, idEvalCred);
        }

        public DataTable ADListaCredAprobadosGrupSolXFechaYGrupo(DateTime dFechaIni, DateTime dFechaFin, int idGrupoSolidario)
        {
            return objEjeSp.EjecSP("CRE_ListaCredAprobadosGrupSolXFechaYGrupo_SP", dFechaIni, dFechaFin, idGrupoSolidario);
        }

        public DataTable ObtenerComentarioRevisor(int idEvalCred, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerComentarioRevisor_SP", idEvalCred, idSolicitud);
        }
    }
}
    