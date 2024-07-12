using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADCategoriaOficina
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarCategoriaOficina(bool lSoloVigentes, int idPeriodoCateOfi)
        {
            return objEjeSp.EjecSP("CRE_ListarCategoriaOficinas_SP", lSoloVigentes, idPeriodoCateOfi);
        }
        public DataTable InsertarCategoriaOficina(string cCategoriaOfi, int idPeriodoCateOfi, bool lVigente, int idUsuarioRegistra)
        {
            return objEjeSp.EjecSP("CRE_InsertarCategoriaOficinas_SP", cCategoriaOfi, idPeriodoCateOfi, lVigente, idUsuarioRegistra);
        }
        public DataTable ActualizarCategoriaOficina(int idCategoriaOfi, string cCategoriaOfi, int idPeriodoCateOfi, bool lVigente, int idUsuarioActualiza)
        {
            return objEjeSp.EjecSP("CRE_ActualizarCategoriaOficinas_SP", idCategoriaOfi, cCategoriaOfi, idPeriodoCateOfi, lVigente, idUsuarioActualiza);
        }
        public DataTable ListarInformacionCateOfi()
        {
            return objEjeSp.EjecSP("CRE_ListarInformacionCateOfi_SP");
        }
        public DataTable listarCategoriaXGrupo(int idGrupoCate)
        {
            return objEjeSp.EjecSP("CRE_ListarCategoriasXGrupo_SP", idGrupoCate);
        }
        public DataTable insertarRecategorizacion(DateTime dFechaInicio, DateTime dFechaFin, int idOficina, int idGrupo, int idCategoria, int idHistCatOficinaAnt, string cJustificacion, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension, int idUsuReg, DateTime dFechaReg)
        {
            return objEjeSp.EjecSP("CRE_GrabarRecategorizacion_SP", dFechaInicio, dFechaFin, idOficina, idGrupo, idCategoria, idHistCatOficinaAnt, cJustificacion, cDocumentoSesion, vDocumentoSesion, cExtension, idUsuReg, dFechaReg);
        }
        public DataTable listarDatosCategorizacion(int idEstadoCateOfi)
        {
            return objEjeSp.EjecSP("CRE_ListarDetalleRecatXHistorico_SP", idEstadoCateOfi);
        }
        public DataTable actualizarRecategorizacion(Boolean lTipo, int idHistCatOficina, DateTime dFechaInicio, DateTime dFechaFin, int idCategoria, int idGrupo, String cJustificacion, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension, int idUsuMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("CRE_ActualizarRecategorizacionOficina_SP", lTipo, idHistCatOficina, dFechaInicio, dFechaFin, idCategoria, idGrupo, cJustificacion, cDocumentoSesion, vDocumentoSesion, cExtension, idUsuMod, dFechaMod);
        }
        public DataTable obtenerDocRecategorizacion(int idHistCatOficina)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDocRecategorizacion_SP", idHistCatOficina);
        }
        public DataTable eliminarRecategorizacion(int idHistCatOficina, int idUsuMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("CRE_EliminarRecategorizacionPendiente_SP", idHistCatOficina, idUsuMod, dFechaMod);
        }
        public DataTable obtenerPeriodoCateOfi(Boolean lSoloVigentes, int idPeriodoCateOfi)
        {
            return objEjeSp.EjecSP("CRE_ListarPeriodoCateOfi_SP", lSoloVigentes, idPeriodoCateOfi);
        }
        public DataTable listarEstadosCateOfi()
        {
            return objEjeSp.EjecSP("CRE_ListarEstadosCateOfi_SP");
        }
        public DataTable grabarPeriodoCateOfi(String cNombre, String cDescripcion, DateTime dFechaInicio, int idEstadoCateOfi, int idUsuReg, DateTime dFechaReg, Boolean lVigente)
        {
            return objEjeSp.EjecSP("CRE_GrabarPeriodoCateOfi_SP", cNombre, cDescripcion, dFechaInicio, idEstadoCateOfi, idUsuReg, dFechaReg, lVigente);
        }
        public DataTable actualizarPeriodoCateOfi(int idPeriodoCateOfi, String cNombre, String cDescripcion, DateTime dFechaInicio, int idEstadoCateOfi, int idUsuMod, DateTime dFechaMod, Boolean lVigente)
        {
            return objEjeSp.EjecSP("CRE_ActualizarPeriodoCateOfi_SP", idPeriodoCateOfi, cNombre, cDescripcion, dFechaInicio, idEstadoCateOfi, idUsuMod, dFechaMod, lVigente);
        }


        public DataTable obtenerGrupoOfi()
        {
            return objEjeSp.EjecSP("CRE_ObtenerGrupoOfi_Sp");
        }

        public DataTable obtenerCategoriaOfi()
        {
            return objEjeSp.EjecSP("CRE_ObtenerCategoriaOfi_Sp");
        }

        public DataTable obtenerCategorizacionOfi(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerHistCatOficina_Sp", dFechaDesde, dFechaHasta);
        }

        public DataTable obtenerCategorizacionOfiAut(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CRE_ListarRecategorizacionesAutomaticas_SP", dFechaDesde, dFechaHasta);
        }
        
        public DataTable obtenerGrupoCompCatOfi(int idPeriodo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerGrupoCompCatOfi_Sp", idPeriodo);
        }
        public DataTable GuardarGrupoOficina(int idPeriodo, string xmlGrupoOfi, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarGrupoOfi_Sp", idPeriodo, xmlGrupoOfi, idUsuario);
        }

        public DataTable ListarGrupoOficina(bool lSoloVigentes, int idPeriodoCateOfi)
        {
            return objEjeSp.EjecSP("CRE_ListarGrupoOficinas_SP", lSoloVigentes, idPeriodoCateOfi);
        }
        public DataTable ListarPeriodoCateOficina(bool lSoloVigentes)
        {
            return objEjeSp.EjecSP("CRE_ListarPeriodoCateOficina_SP", lSoloVigentes);
        }

        public DataTable ListarVincGrupoCateOfi(int idPeriodo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerVincGrupoCateOfi_Sp", idPeriodo);
        }

        public DataTable GuardarVincGrupoCat(int idPeriodo, string xmlGrupoOfi, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardarVincGrupoOfi_SP", idPeriodo, xmlGrupoOfi, idUsuario);
        }

    }
}
