using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace CAJ.AccesoDatos
{
    public class clsADVisitaSupervisionOperacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarVisitaSupervisionOperacion(int idZona, int idAgencia, int idEstablecimiento, int idUsuario, int idEstado, string cTipoSupervision, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_ListarVisitaSupervisionOperaciones_SP", idZona, idAgencia, idEstablecimiento, idUsuario, idEstado, cTipoSupervision, dFechaIni, dFechaFin);
        }

        public DataTable listarBloquePreguntas(int idGrupo, int idVisita)
        {
            return objEjeSp.EjecSP("CAJ_ListarPreguntasDeGrupo_SP", idGrupo, idVisita);
        }

        public DataTable listarGrupoPreguntas(int idTipoVisita)
        {
            return objEjeSp.EjecSP("CAJ_ListarGrupoPreguntas_SP", idTipoVisita);
        }

        public DataTable guardarNuevaVisita(int idUsuario, int idEstablecimiento, string cTipoSupervision, int idPerfil)
        {
            return objEjeSp.EjecSP("CAJ_CrearNuevaVisitaSupervisionOperacion_SP", idUsuario, idEstablecimiento, cTipoSupervision, idPerfil);
        }

        public DataTable ListarPerfilAsigXUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_ListarPerfilAsignado_SP", idUsuario);
        }

        public DataTable agregarIntervinienteColaborador(int idVisita, int idUsuario, int idPerfil, int nTipo)
        {
            return objEjeSp.EjecSP("CAJ_AgregarIntervieneSupervisionOperacion_SP", idVisita, idUsuario, idPerfil, nTipo);
        }

        public DataTable listarIntervieneVisita(int idVisita)
        {
            return objEjeSp.EjecSP("CAJ_ListarIntervieneSupervisionOperacion_SP", idVisita);
        }

        public DataSet listarResumenEvaluacion(int idVisita)
        {
            return objEjeSp.DSEjecSP("CAJ_ListarResumenSupervisionOperacion_SP", idVisita);
        }

        public DataTable guardarRespuesta(int idVisita, int idPregunta, string cCumple, string cComentario, int nCantSistema, int nCantFisico, int nCantDiferencia, decimal nNota)
        {
            return objEjeSp.EjecSP("CAJ_GuardarRespuestaSupervisionOperacion_SP", idVisita, idPregunta, cCumple, cComentario, nCantSistema, nCantFisico, nCantDiferencia, nNota);
        }

        public DataTable listarDatosRespuestaPregunta(int idVisita, int idPregunta)
        {
            return objEjeSp.EjecSP("CAJ_ListarRespuestaPreguntaSupervOpe_SP", idVisita, idPregunta);
        }

        public DataTable listarSupervisorZona(int idZona)
        {
            return objEjeSp.EjecSP("CAJ_ListarSupervisorZona_SP", idZona, clsVarGlobal.User.idCargo);
        }

        public DataTable rtpResultadoVisita(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoVisita, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_RptResultadosVisitaSupervisionOpe_SP", idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoVisita, dFechaIni, dFechaFin);
        }

        public DataTable rtpObservadosVisita(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoVisita, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_RptObservadosSupervisionOpe_SP", idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoVisita, dFechaIni, dFechaFin);
        }

        public DataTable getZonaUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_ObtenerDatosUsuarioZona_SP", idUsuario);
        }

        public DataTable listarCantidadPregunta(int idVisita, int idGrupo)
        {
            return objEjeSp.EjecSP("CAJ_ListarItemsEvaluados_SP", idVisita, idGrupo);
        }

        public DataTable rptResumenVisitaSupervision(int idVisita)
        {
            return objEjeSp.EjecSP("CAJ_RptResumenRespuestasSupervisionOpe_SP", idVisita);
        }

        public DataTable listarArchivosVisita(int idVisita, int idPregunta)
        {
            return objEjeSp.EjecSP("CAJ_ListarArchivoSupervisionOperacion_SP", idVisita, idPregunta);
        }

        public DataTable obtenerArchivoVisita(int idArchivo)
        {
            return objEjeSp.EjecSP("CAJ_ObtenerArchivoSupervisionOpe_SP", idArchivo);
        }

        public DataTable guardarArchivoSupervision(int idVisita, int idPregunta, string cFile, byte[] bBinaryFile, int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CAJ_GuardarArchivoSupervisionOpe_SP", idVisita, idPregunta, cFile, bBinaryFile, idUsuario, idPerfil);
        }

        public DataTable guardarConformidadUsuario(int idVisita, int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_GuardarConformidadSupervisionOpe_SP", idVisita, idUsuario);
        }

        public DataTable finalizarVisitaSupervision(int idVisita, int idUsuario)
        {
            return objEjeSp.EjecSP("CAJ_FinalizarSupervisionOperacion_SP", idVisita, idUsuario);
        }

        public DataTable getDatosVisita(int idVisita)
        {
            return objEjeSp.EjecSP("CAJ_EstadoSupervisionOperacion_SP", idVisita);
        }

        public DataTable getAnexoVisita(int idVisita)
        {
            return objEjeSp.EjecSP("CAJ_AnexosSupervisionOperacion_SP", idVisita);
        }

        public DataTable guardarAnexoVisita(int idVisita, string cNombreArchivo, byte[] bArchivo)
        {
            return objEjeSp.EjecSP("CAJ_GuardarAnexosSupervisionOperacion_SP", idVisita, cNombreArchivo, bArchivo);
        }

        public DataTable quitarArchivoSupervision(int idArchivo)
        {
            return objEjeSp.EjecSP("CAJ_QuitarArchivoSupervisionOpe_SP", idArchivo);
        }

        public DataTable eliminarVisitaSupervisionOperacion(int idVisita)
        {
            return objEjeSp.EjecSP("CAJ_EliminarVisitaSupervisionOperacion_SP", idVisita);
        }
        #region Arqueo de Bóveda y Ventanilla
        public DataSet listarBilletajeResponsable(int idVisita, int idUsuario, int idTipResp)
        {
            return objEjeSp.DSEjecSP("CAJ_ListarBilletajeArqueoInopinado_SP", idVisita, idUsuario, idTipResp);
        }

        public DataTable iniciarBilletajeSupervision(int idVisita, int idUsuario, int idTipResCaj, int idSupervisor, int idPerfil)
        {
            return objEjeSp.EjecSP("CAJ_IniciarBilletajeArqueoInopinado_SP", idVisita, idUsuario, idTipResCaj, idSupervisor, idPerfil);
        }

        public DataTable guardarBilletaje(int idBilletaje, int idSupervisor, string xmlMonedas, string xmlBilleteSoles, string xmlBilleteDolar)
        {
            return objEjeSp.EjecSP("CAJ_GuardarBilletajeArqueoInopinado_SP", idBilletaje, idSupervisor, xmlMonedas, xmlBilleteSoles, xmlBilleteDolar);
        }

        public DataTable listarResponsablesVisitaEstablecimiento(int idVisita, int idEstablecimiento, int idTipoResCaj)
        {
            return objEjeSp.EjecSP("CAJ_ListarResponsableVisitaEstablecimiento_SP", idVisita, idEstablecimiento, idTipoResCaj);
        }

        public DataTable guardarConformidadBilletaje(int idBilletaje, int idSupervisor)
        {
            return objEjeSp.EjecSP("CAJ_GuardarConformidadArqueoInopinado_SP", idBilletaje, idSupervisor);
        }

        public DataTable guardarObservacionAccion(int idBilletaje, string cObservacion, string cAccion, int idSupervisor)
        {
            return objEjeSp.EjecSP("CAJ_GuardarObservacionAccionArqueoInopinado_SP", idBilletaje, cObservacion, cAccion, idSupervisor);
        }

        public DataTable anularBilletaje(int idBilletaje, int idMotivoAnular, string cSustento, int idSupervisor)
        {
            return objEjeSp.EjecSP("CAJ_GuardarAnulacionArqueoInopinado_SP", idBilletaje, idMotivoAnular, cSustento, idSupervisor);
        }

        public DataTable obtenerDiferenciaArqueoInopinado(int idVisita, string cTipoVisita)
        {
            return objEjeSp.EjecSP("CAJ_ObtenerDiferenciaArqueoInopinado_SP", idVisita, cTipoVisita);
        }

        public DataTable obtenerTipoSupervision(string cTipoSupervision)
        {
            return objEjeSp.EjecSP("GEN_ListarTipoVisitaAreaUsuario_SP", cTipoSupervision);
        }

        public DataTable rptArqueoInopinado(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoVisita, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_ReporteArqueoInopinado_SP", idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoVisita, dFechaIni, dFechaFin);
        }

        public DataTable getMotivosAnularBilletaje()
        {
            return objEjeSp.EjecSP("GEN_ListarMotivoAnularArqueoInopinado_SP");
        }

        public DataTable validarArqueoInopinado(int idVisita, string cTipoSupervision)
        {
            return objEjeSp.EjecSP("CAJ_ValidarArqueoInopinado_SP", idVisita, cTipoSupervision);
        }

        public DataTable guardarSustentoSinConformidad(int idBilletaje, int idSupervisor)
        {
            return objEjeSp.EjecSP("CAJ_GuardarSustentoSinConformidadArqueoInopinado_SP", idBilletaje, idSupervisor);
        }
        #endregion
    }
}
