using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.AccesoDatos;

namespace CAJ.CapaNegocio
{
    public class clsCNVisitaSupervisionOperacion
    {
        clsADVisitaSupervisionOperacion clsVisita = new clsADVisitaSupervisionOperacion();

        public DataTable listarVisitaSupervisionOperacion(int idZona, int idAgencia, int idEstablecimiento, int idUsuario, int idEstado, string cTipoSupervision, DateTime dFechaIni, DateTime dFechaFin)
        {
            return clsVisita.listarVisitaSupervisionOperacion(idZona, idAgencia, idEstablecimiento,idUsuario, idEstado, cTipoSupervision, dFechaIni, dFechaFin);
        }

        public DataTable listarBloquePreguntas(int idGrupo, int idVisita)
        {
            return clsVisita.listarBloquePreguntas(idGrupo, idVisita);
        }

        public DataTable listarGrupoPreguntas(int idTipoVisita)
        {
            return clsVisita.listarGrupoPreguntas(idTipoVisita);
        }

        public DataTable guardarNuevaVisita(int idUsuario, int idEstablecimiento, string cTipoSupervision, int idPerfil)
        {
            return clsVisita.guardarNuevaVisita(idUsuario, idEstablecimiento, cTipoSupervision, idPerfil);
        }

        public DataTable ListarPerfilAsigXUsuario(int idUsuario)
        {
            return clsVisita.ListarPerfilAsigXUsuario(idUsuario);
        }

        public DataTable agregarIntervinienteColaborador(int idVisita,int idUsuario, int idPerfil, int nTipo)
        {
            return clsVisita.agregarIntervinienteColaborador(idVisita, idUsuario, idPerfil, nTipo);
        }

        public DataTable listarIntervieneVisita(int idVisita)
        {
            return clsVisita.listarIntervieneVisita(idVisita);
        }

        public DataSet listarResumenEvaluacion(int idVisita)
        {
            return clsVisita.listarResumenEvaluacion(idVisita);
        }

        public DataTable guardarRespuesta(int idVisita, int idPregunta, string cCumple, string cComentario, int nCantSistema, int nCantFisico, int nCantDiferencia, decimal nNota)
        {
            return clsVisita.guardarRespuesta(idVisita, idPregunta, cCumple, cComentario, nCantSistema, nCantFisico, nCantDiferencia, nNota);
        }

        public DataTable listarDatosRespuestaPregunta(int idVisita, int idPregunta)
        {
            return clsVisita.listarDatosRespuestaPregunta(idVisita, idPregunta);
        }

        public DataTable listarSupervisorZona(int idZona)
        {
            return clsVisita.listarSupervisorZona(idZona);
        }

        public DataTable rptResultadoVisita(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoVisita, DateTime dFechaIni, DateTime dFechaFin)
        {
            return clsVisita.rtpResultadoVisita(idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoVisita, dFechaIni, dFechaFin);
        }

        public DataTable rptObservadosVisita(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoVisita, DateTime dFechaIni, DateTime dFechaFin)
        {
            return clsVisita.rtpObservadosVisita(idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoVisita, dFechaIni, dFechaFin);
        }
        
        public DataTable getZonaUsuario(int idUsuario)
        {
            return clsVisita.getZonaUsuario(idUsuario);
        }

        public DataTable listarCantidadPregunta(int idVisita, int idGrupo)
        {
            return clsVisita.listarCantidadPregunta(idVisita, idGrupo);
        }

        public DataTable rptResumenVisitaSupervision(int idVisita)
        {
            return clsVisita.rptResumenVisitaSupervision(idVisita);
        }

        public DataTable listarArchivosVisita(int idVisita, int idPregunta)
        {
            return clsVisita.listarArchivosVisita(idVisita, idPregunta);
        }

        public DataTable obtenerArchivoVisita(int idArchivo)
        {
            return clsVisita.obtenerArchivoVisita(idArchivo);
        }

        public DataTable guardarArchivoSupervision(int idVisita, int idPregunta, string cFile, byte[] bBinaryFile, int idUsuario, int idPerfil)
        {
            return clsVisita.guardarArchivoSupervision(idVisita, idPregunta, cFile, bBinaryFile, idUsuario, idPerfil);
        }

        public DataTable guardarConformidadUsuario(int idVisita, int idUsuario)
        {
            return clsVisita.guardarConformidadUsuario(idVisita, idUsuario);
        }

        public DataTable finalizarVisitaSupervision(int idVisita, int idUsuario)
        {
            return clsVisita.finalizarVisitaSupervision(idVisita, idUsuario);
        }

        public DataTable getDatosVisita(int idVisita)
        {
            return clsVisita.getDatosVisita(idVisita);
        }

        public DataTable getAnexoVisita(int idVisita)
        {
            return clsVisita.getAnexoVisita(idVisita);
        }

        public DataTable guardarAnexoVisita(int idVisita, string cNombreArchivo, byte[] bArchivo)
        {
            return clsVisita.guardarAnexoVisita(idVisita, cNombreArchivo, bArchivo);
        }

        public DataTable quitarArchivoSupervision(int idArchivo)
        {
            return clsVisita.quitarArchivoSupervision(idArchivo);
        }

        public DataTable eliminarVisitaSupervisionOperacion(int idVisita)
        {
            return clsVisita.eliminarVisitaSupervisionOperacion(idVisita);
        }

        #region Arqueo de Bóveda y Ventanilla
        public DataSet listarBilletajeResponsable(int idVisita, int idUsuario, int idTipRespCaj)
        {
            return clsVisita.listarBilletajeResponsable(idVisita, idUsuario, idTipRespCaj);
        }

        public DataTable iniciarBilletajeSupervision(int idVisita, int idUsuario, int idTipResCaj, int idSupervisor, int idPerfil)
        {
            return clsVisita.iniciarBilletajeSupervision(idVisita, idUsuario, idTipResCaj, idSupervisor, idPerfil);
        }

        public DataTable guardarBilletaje(int idBilletaje, int idSupervisor, string xmlMonedas, string xmlBilleteSoles, string xmlBilleteDolar)
        {
            return clsVisita.guardarBilletaje(idBilletaje, idSupervisor, xmlMonedas, xmlBilleteSoles, xmlBilleteDolar);
        }

        public DataTable listarResponsablesVisitaEstablecimiento(int idVisita, int idEstablecimiento, int idTipoResCaj)
        {
            return clsVisita.listarResponsablesVisitaEstablecimiento(idVisita, idEstablecimiento, idTipoResCaj);
        }

        public DataTable guardarConformidadBilletaje(int idBilletaje, int idSupervisor)
        {
            return clsVisita.guardarConformidadBilletaje(idBilletaje, idSupervisor);
        }

        public DataTable guardarObservacionAccion(int idBilletaje, string cObservacion, string cAccion, int idSupervisor)
        {
            return clsVisita.guardarObservacionAccion(idBilletaje, cObservacion, cAccion, idSupervisor);
        }

        public DataTable anularBilletaje(int idBilletaje, int idMotivoAnular, string cSustento, int idSupervisor)
        {
            return clsVisita.anularBilletaje(idBilletaje, idMotivoAnular, cSustento, idSupervisor);
        }

        public DataTable obtenerDiferenciaArqueoInopinado(int idVisita, string cTipoVisita)
        {
            return clsVisita.obtenerDiferenciaArqueoInopinado(idVisita, cTipoVisita);
        }

        public DataTable obtenerTipoSupervision(string cTipoSupervision)
        {
            return clsVisita.obtenerTipoSupervision(cTipoSupervision);
        }

        public DataTable rptArqueoInopinado(int idZona, int idAgencia, int idEstablecimiento, int idSupervisor, int idEstado, string cTipoVisita, DateTime dFechaIni, DateTime dFechaFin)
        {
            return clsVisita.rptArqueoInopinado(idZona, idAgencia, idEstablecimiento, idSupervisor, idEstado, cTipoVisita, dFechaIni, dFechaFin);
        }

        public DataTable getMotivosAnularBilletaje()
        {
            return clsVisita.getMotivosAnularBilletaje();
        }

        public DataTable validarArqueoInopinado(int idVisita, string cTipoSupervision)
        {
            return clsVisita.validarArqueoInopinado(idVisita, cTipoSupervision);
        }

        public DataTable guardarSustentoSinConformidad(int idBilletaje, int idSupervisor)
        {
            return clsVisita.guardarSustentoSinConformidad(idBilletaje, idSupervisor);
        }
        #endregion
    }
}
