using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRE.AccesoDatos;
using System.Data;
using EntityLayer;
namespace CRE.CapaNegocio
{
    public class clsCNAprobacionCredito
    {
        private clsADAprobacionCredito objAprobacionCredito = new clsADAprobacionCredito();

        //TODO: SolTechnologies - 36.Se añadio la opcion de un usuario por defecto
        public DataTable GestionarAprobacion(int idSolicitud, int idEvalCred, int idAgencia, decimal nMonto, bool automatico)
        {
            if (automatico)
            {
                return objAprobacionCredito.GestionarAprobacion(idSolicitud, idEvalCred, idAgencia, nMonto, 224, 3265); //Eduardo Santamaria (Usuario Aprobador)
            }
            else
            {
                return objAprobacionCredito.GestionarAprobacion(idSolicitud, idEvalCred, idAgencia, nMonto, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario);
            }
               
        }

        public DataTable NroExcepcionesCredito(int idSolicitud)
        {
            return objAprobacionCredito.NroExcepcionesCredito(idSolicitud);
        }
        public DataTable NroExcepcionesCreditoGrupoSolidario(int idSolicitudCredGrupoSol)
        {
            return objAprobacionCredito.NroExcepcionesCreditoGrupoSolidario(idSolicitudCredGrupoSol);
        }
        
        public DataTable GuardarGestionAprobacion(int idSolicitud, int idEvalCred, int idUsuario,int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision)
        {
            return objAprobacionCredito.GuardarGestionAprobacion(idSolicitud,idEvalCred,idUsuario,idEstadoEvalCred,idEtapaEvalCred,idNivelAproSig,lEnviarSolInfRiesgos,lRevision);
        }


        public DataTable GuardarDecisionComite(int idEvalComiteCred, int idSolicitud, int idEvalCred, int idUsuario, int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision,
            string cComentario, string cComentRev, bool lVerificacion, int idMotRechazo)
        {
            return objAprobacionCredito.GuardarDecisionComite(idEvalComiteCred, idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision,
                cComentario, cComentRev, lVerificacion, idMotRechazo);
        }

        public DataTable GuardarDecisionAprobador(int idSolicitud, int idEvalCred, int idUsuario,int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision,
            string cComentario, bool lVerificacion, int idMotRechazo, DateTime dFechaFin)
        {
            return objAprobacionCredito.GuardarDecisionAprobador(idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision,
                cComentario,lVerificacion,idMotRechazo,dFechaFin);
        }

        public DataTable GuardarDecisionAprobadorGrupal(int idSolicitudCredGrupoSol, int idEvalCredGrupoSol, string xmlEvalCredIntegGrupoSol, int idUsuario, int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAproSig, bool lEnviarSolInfRiesgos, bool lRevision,
            string cComentario, bool lVerificacion, int idMotRechazo, DateTime dFechaFin)
        {
            return objAprobacionCredito.GuardarDecisionAprobadorGrupal(idSolicitudCredGrupoSol, idEvalCredGrupoSol, xmlEvalCredIntegGrupoSol, idUsuario, idEstadoEvalCred, idEtapaEvalCred, idNivelAproSig, lEnviarSolInfRiesgos, lRevision,
                cComentario, lVerificacion, idMotRechazo, dFechaFin);
        }

        public DataTable ActualizarCondicionesCredito(int idEvalCred, int idSolicitud, decimal nMonto, int nCuotas, int idTipoPeriodo, int nPlazoCuota, int nPlazo, int nCuotasGracia, int nDiasGracia, DateTime dFechaDesemProp, int idProducto, int idTasa, decimal nTasa)
        {
            return objAprobacionCredito.ActualizarCondicionesCredito(idEvalCred,idSolicitud, nMonto, nCuotas, idTipoPeriodo, nPlazoCuota,nPlazo, nCuotasGracia, nDiasGracia, dFechaDesemProp, idProducto,idTasa,nTasa);
        }

        public clsCreditoProp ObtenerCondicionesCredito(int idEvalCred)
        {
            return objAprobacionCredito.ObtenerCondicionesCredito(idEvalCred);
        }

        public clsAprobacionEvalCred InicializarAprobacionEvalCred(int idEvalCred, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objAprobacionCredito.InicializarAprobacionEvalCred(idEvalCred, idUsuario, idPerfil, dFechaSistema);
        }

        public clsAproEvalCredGrupoSol IniciaAprobacionEvalCredGrupal(int idEvalCredGrupoSol, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objAprobacionCredito.IniciaAprobacionEvalCredGrupal(idEvalCredGrupoSol, idUsuario, idPerfil, dFechaSistema);
        }

        public clsRevisionEvalCred InicializarRevisionEvalCred(int idEvalCred, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objAprobacionCredito.InicializarRevisionEvalCred(idEvalCred, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable GuardarDecisionRevisor(int idSolicitud, int idEvalCred, int idUsuario, int idEstadoEvalCred, int idNivelAproSig, string cComentario, bool lVerificacion, DateTime dFechaFin)
        {
            return objAprobacionCredito.GuardarDecisionRevisor( idSolicitud, idEvalCred, idUsuario, idEstadoEvalCred, idNivelAproSig, cComentario, lVerificacion, dFechaFin);
        }

        public DataTable GestionarAprobacionGrupal(int idSolicitudCredGrupoSol, int idEvalCredGrupoSol, int idAgencia, decimal nMonto)
        {
            return objAprobacionCredito.GestionarAprobacionGrupal(idSolicitudCredGrupoSol, idEvalCredGrupoSol, idAgencia, nMonto);
        }
        public DataTable ActaCreditoGrupoSol(int idGrupo, int idSolicitudGrupo)
        {
            return objAprobacionCredito.ActaCreditoGrupoSol(idGrupo, idSolicitudGrupo);
        }
        public DataTable ActaCreditoGrupoSol2(int idGrupo, int idSolicitudGrupo)
        {
            return objAprobacionCredito.ActaCreditoGrupoSol2(idGrupo, idSolicitudGrupo);
        }
        public DataTable ActaCreditoGrupoSol3(int idGrupo, int idSolicitudGrupo)
        {
            return objAprobacionCredito.ActaCreditoGrupoSol3(idGrupo, idSolicitudGrupo);
        }
        public DataTable ActaCreditoGrupoSol4(int idGrupo, int idSolicitudGrupo)
        {
            return objAprobacionCredito.ActaCreditoGrupoSol4(idGrupo, idSolicitudGrupo);
        }
        public DataTable LisNivelAprobaSolCredGrupoSol(int idSolicitudGrupoSol)
        {
            return objAprobacionCredito.LisNivelAprobaSolCredGrupoSol(idSolicitudGrupoSol);
        }
        public DataTable CNDeterUsuPuedeAprobaEval(int idUsuario, int idPerfil, int idEvalCred)
        {
            return objAprobacionCredito.ADDeterUsuPuedeAprobaEval(idUsuario, idPerfil, idEvalCred);
        }
        
        public DataTable CNListaCredAprobadosGrupSolXFechaYGrupo(DateTime dFechaIni, DateTime dFechaFin, int idGrupoSolidario)
        {
            return objAprobacionCredito.ADListaCredAprobadosGrupSolXFechaYGrupo(dFechaIni, dFechaFin, idGrupoSolidario);
        }

        public DataTable ObtenerComentarioRevisor(int idEvalCred, int idSolicitud)
        {
            return objAprobacionCredito.ObtenerComentarioRevisor(idEvalCred, idSolicitud);
        }
        
    }
}
