using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNExcepcionesCreditos
    {
        public clsADExcepcionesCreditos ObjCredito = new clsADExcepcionesCreditos();

        
          public DataTable cargarDatosExcepciones(int idSolicitud)
        {
            return ObjCredito.cargarDatosExcepciones(idSolicitud);
        }
        public DataTable cargarDatosExcepcionesGrupoSolidario(int idSolicitudCredGrupoSol)
        {
            return ObjCredito.cargarDatosExcepcionesGrupoSolidario(idSolicitudCredGrupoSol);
        }

        public DataTable GuardaOpinionExcepciones(int nNivelActual, int nNivelAprobacion, int idSolicitud, int idExcepGen, int opinion, int idUsuReg)
        {
            return ObjCredito.GuardaOpinionExcepciones(nNivelActual, nNivelAprobacion, idSolicitud, idExcepGen, opinion, idUsuReg);
        }

        public DataTable obtenerReporteExcepciones(DateTime dtDesde, DateTime dtA)
        {
            return ObjCredito.obtenerReporteExcepciones(dtDesde, dtA);
        }
          
        public DataTable ContExcepcionesPorEstado(int idSolicitud)
        {
            return ObjCredito.ContExcepcionesPorEstado(idSolicitud);
        }
        public DataTable obtenerReglas(int idSolicitud)
        {
            return ObjCredito.obtenerRegla(idSolicitud);
        }

        public List<clsExcepReglaNegResum> listSolicExcepAprobacion(int idSolicitud, int idUsuario, int idPerfil)
        {
            DataTable dtExcepReglaNeg = this.ObjCredito.listSolicExcepAprobacion(idPerfil, idUsuario, idSolicitud);

            return (dtExcepReglaNeg.Rows.Count > 0) ?
                dtExcepReglaNeg.ToList<clsExcepReglaNegResum>() as List<clsExcepReglaNegResum> :
                new List<clsExcepReglaNegResum>();
        }

        public List<clsExcepReglaNegResum> listSolicExcepAprobacion(int idSolicitud)
        {
            DataTable dtExcepReglaNeg = this.ObjCredito.listSolicExcepAprobacion(clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario, idSolicitud);

            return (dtExcepReglaNeg.Rows.Count > 0) ?
                dtExcepReglaNeg.ToList<clsExcepReglaNegResum>() as List<clsExcepReglaNegResum> :
                new List<clsExcepReglaNegResum>();
        }

        public clsResolucionExcepcionReglaNeg obtenerResolucionExcepReglaNeg(int idSolicitud, int idUsuario, int idPerfil)
        {
            DataTable dtResolucionExcepReglaNeg = this.ObjCredito.obtenerResolucionExcepReglaNeg(idSolicitud, idUsuario, idPerfil);

            return (dtResolucionExcepReglaNeg.Rows.Count > 0) ?
                dtResolucionExcepReglaNeg.Rows[0].ToObject<clsResolucionExcepcionReglaNeg>() :
                new clsResolucionExcepcionReglaNeg();
        }

        public clsResolucionExcepcionReglaNeg obtenerResolucionExcepReglaNeg(int idSolicitud)
        {
            DataTable dtResolucionExcepReglaNeg = this.ObjCredito.obtenerResolucionExcepReglaNeg(idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            return (dtResolucionExcepReglaNeg.Rows.Count > 0) ?
                dtResolucionExcepReglaNeg.Rows[0].ToObject<clsResolucionExcepcionReglaNeg>() :
                new clsResolucionExcepcionReglaNeg();
        }

        public List<clsExcepcionReglaNeg> listarExcepcionReglaNeg(int idSolicitud, string cNombreForm)
        {
            DataTable dtExcepReglaNeg = this.ObjCredito.listarExcepcionReglaNeg(idSolicitud, cNombreForm, 0, 0);

            return (dtExcepReglaNeg.Rows.Count > 0) ?
                dtExcepReglaNeg.ToList<clsExcepcionReglaNeg>() as List<clsExcepcionReglaNeg> :
                new List<clsExcepcionReglaNeg>();
        }

        public List<clsExcepcionReglaNeg> listarExcepcionReglaNeg(int idSolicitud, string cNombreForm, int idUsuarioAprobador, int idPerfilAprobador)
        {
            DataTable dtExcepReglaNeg = this.ObjCredito.listarExcepcionReglaNeg(idSolicitud, cNombreForm, idUsuarioAprobador, idPerfilAprobador);

            return (dtExcepReglaNeg.Rows.Count > 0) ?
                dtExcepReglaNeg.ToList<clsExcepcionReglaNeg>() as List<clsExcepcionReglaNeg> :
                new List<clsExcepcionReglaNeg>();
        }
        public clsRespuestaServidor grabarExcepcionReglaNeg(List<clsExcepcionReglaNeg> lstExcepcionReglaNeg,
            int idSolicitud, string cNombreForm, int idEstado)
        {
            string xmlExcepReglaNeg = lstExcepcionReglaNeg.ListObjectToXml("Excepcion","Excepciones");
            DataTable dtRespuesta = this.ObjCredito.grabarExcepcionReglaNeg(xmlExcepReglaNeg, idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cNombreForm, idEstado);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor inicializarExcepcionReglaNeg(int idSolicitud, string cNombreForm)
        {
            DataTable dtRespuesta = this.ObjCredito.inicializarExcepcionReglaNeg(idSolicitud, clsVarGlobal.User.idUsuario, cNombreForm, clsVarGlobal.dFecSystem);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsRespuestaServidor registrarDecisionExcepcionRegla(int idSolicitud, int idExcepcionReglaNeg, int idEstado, string cComentarioAprobador, int idUsuarioAprobador, int idPerfilAprobador)
        {
            DataTable dtRespuesta = this.ObjCredito.registrarDecisionExcepcionRegla(idSolicitud, idExcepcionReglaNeg, idEstado, idUsuarioAprobador, idPerfilAprobador, cComentarioAprobador);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsRespuestaServidor registrarDecisionExcepcionRegla(int idSolicitud, int idExcepcionReglaNeg, int idEstado, string cComentarioAprobador)
        {
            DataTable dtRespuesta = this.ObjCredito.registrarDecisionExcepcionRegla(idSolicitud, idExcepcionReglaNeg, idEstado, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, cComentarioAprobador);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsRespuestaServidor anularExcepcionReglaNegocio(int idExcepcionReglaNeg, String cNombreForm)
        {
            DataTable dtRespuesta = this.ObjCredito.anularExcepcionReglaNegocio(idExcepcionReglaNeg, clsVarGlobal.User.idUsuario, cNombreForm);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsRespuestaServidor validarAprobExcepcioneReglaNeg(int idSolicitud, int idUsuario, int idPerfil)
        {
            DataTable dtRespuesta = this.ObjCredito.validarAprobExcepcioneReglaNeg(idSolicitud, idUsuario, idPerfil);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsRespuestaServidor validarAprobExcepcioneReglaNeg(int idSolicitud)
        {
            DataTable dtRespuesta = this.ObjCredito.validarAprobExcepcioneReglaNeg(idSolicitud, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
    }
}
