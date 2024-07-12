using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADExcepcionesCreditos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable cargarDatosExcepciones(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListaExcepcionesGeneradas_SP", idSolicitud);
        }
        public DataTable cargarDatosExcepcionesGrupoSolidario(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_ListaExcepcionesGeneradasGrupales_SP", idSolicitudCredGrupoSol);
        }
        public DataTable GuardaOpinionExcepciones(int nNivelActual, int nNivelAprobacion, int idSolicitud, int idExcepGen, int opinion, int idUsuReg)
        {
            return objEjeSp.EjecSP("CRE_GuardaOpinionExcepciones_SP", nNivelActual, nNivelAprobacion, idSolicitud, idExcepGen, opinion, idUsuReg);
        }

        public DataTable obtenerReporteExcepciones(DateTime dtDesde, DateTime dtA)
        {
            return objEjeSp.EjecSP("CRE_ReporteExcepcionesRiesgos", dtDesde, dtA);
        }

        public DataTable ContExcepcionesPorEstado(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ContExcepcionesPorEstado_SP", idSolicitud);
        }

        public DataTable obtenerRegla(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaSolicitudesENC_SP", idSolicitud);
        }
        public DataTable listSolicExcepAprobacion(int idPerfil, int idUsuario, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListSolicExcepAprobacion_SP", idPerfil, idUsuario, idSolicitud);
        }
        public DataTable obtenerResolucionExcepReglaNeg(int idSolicitud, int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ObtenerResolucionExcepReglaNeg_SP", idSolicitud, idUsuario, idPerfil);
        }
        public DataTable listarExcepcionReglaNeg(int idSolicitud, string cNombreForm, int idUsuarioAprobador, int idPerfilAprobador)
        {
            return objEjeSp.EjecSP("CRE_ListarExcepcionReglaNeg_SP", idSolicitud, cNombreForm, idUsuarioAprobador, idPerfilAprobador);
        }
        public DataTable grabarExcepcionReglaNeg(string xmlExcepReglaNeg, int idSolicitud, int idUsuario, DateTime dFechaSistema, string cNombreForm, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_GrabarExcepcionReglaNeg_SP", xmlExcepReglaNeg, idSolicitud, idUsuario, dFechaSistema, cNombreForm, idEstado);
        }
        public DataTable inicializarExcepcionReglaNeg(int idSolicitud, int idUsuario, string cNombreForm, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("CRE_InicializarExcepcionReglaNeg_SP", idSolicitud, idUsuario, cNombreForm, dFechaSistema);
        }
        public DataTable registrarDecisionExcepcionRegla(int idSolicitud, int idExcepcionReglaNeg, int idEstado, int idUsuario, int idPerfil, string cComentarioAprobador)
        {
            return objEjeSp.EjecSP("CRE_RegistrarDecisionExcepcionRegla_SP", idSolicitud, idExcepcionReglaNeg, idEstado, idUsuario, idPerfil, cComentarioAprobador);
        }
        public DataTable anularExcepcionReglaNegocio(int idExcepcionReglaNeg, int idUsuario, string cNombreForm)
        {
            return objEjeSp.EjecSP("CRE_AnularExcepcionReglaNegocio_SP", idExcepcionReglaNeg, idUsuario, cNombreForm);
        }
        public DataTable validarAprobExcepcioneReglaNeg(int idSolicitud, int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ValidarAprobExcepcionReglaNeg_SP", idSolicitud, idUsuario, idPerfil);
        }
    }
}
