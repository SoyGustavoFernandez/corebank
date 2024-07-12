using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNCategoriaOficina
    {
        clsADCategoriaOficina ObjCredito = new clsADCategoriaOficina();

        public DataTable ListarCategoriaOficina(bool lSoloVigente, int idPeriodoCateOfi)
        {
            return ObjCredito.ListarCategoriaOficina(lSoloVigente, idPeriodoCateOfi);
        }
        public DataTable InsertarCategoriaOficina(string cCategoriaOfi, int idPeriodoCateOfi, bool lVigente, int idUsuarioRegistra)
        {
            return ObjCredito.InsertarCategoriaOficina(cCategoriaOfi, idPeriodoCateOfi, lVigente, idUsuarioRegistra);
        }
        public DataTable ListarInformacionCateOfi()
        {
            return ObjCredito.ListarInformacionCateOfi();
        }
        public DataTable listarCategoriaXGrupo(int idGrupoCate)
        {
            return ObjCredito.listarCategoriaXGrupo(idGrupoCate);
        }
        public DataTable insertarRecategorizacion(DateTime dFechaInicio, DateTime dFechaFin, int idOficina, int idGrupo, int idCategoria, int idHistCatOficinaAnt, string cJustificacion, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension, int idUsuReg, DateTime dFechaReg)
        {
            return ObjCredito.insertarRecategorizacion(dFechaInicio, dFechaFin, idOficina, idGrupo, idCategoria, idHistCatOficinaAnt, cJustificacion, cDocumentoSesion, vDocumentoSesion, cExtension, idUsuReg, dFechaReg);
        }
        public DataTable listarDatosCategorizacion(int idEstadoCateOfi)
        {
            return ObjCredito.listarDatosCategorizacion(idEstadoCateOfi);
        }
        public DataTable actualizarRecategorizacion(Boolean lTipo, int idHistCatOficina, DateTime dFechaInicio, DateTime dFechaFin, int idCategoria, int idGrupo, String cJustificacion, string cDocumentoSesion, byte[] vDocumentoSesion, string cExtension, int idUsuMod, DateTime dFechaMod)
        {
            return ObjCredito.actualizarRecategorizacion(lTipo, idHistCatOficina, dFechaInicio, dFechaFin, idCategoria, idGrupo, cJustificacion, cDocumentoSesion, vDocumentoSesion, cExtension, idUsuMod, dFechaMod);
        }

        public DataTable ActualizarCategoriaOficina(int idCategoriaOfi, string cCategoriaOfi, int idPeriodoCateOfi, bool lVigente, int idUsuarioActualiza)
        {
            return ObjCredito.ActualizarCategoriaOficina(idCategoriaOfi, cCategoriaOfi, idPeriodoCateOfi, lVigente, idUsuarioActualiza);

        }
        public DataTable obtenerDocRecategorizacion(int idCategoriaOfi)
        {
            return ObjCredito.obtenerDocRecategorizacion(idCategoriaOfi);
        }
        public DataTable eliminarRecategorizacion(int idCategoriaOfi, int idUsuMod, DateTime dFechaMod)
        {
            return ObjCredito.eliminarRecategorizacion(idCategoriaOfi, idUsuMod, dFechaMod);
        }
        public DataTable obtenerPeriodoCateOfi(Boolean lSoloVigentes, int idPeriodoCateOfi)
        {
            return ObjCredito.obtenerPeriodoCateOfi(lSoloVigentes, idPeriodoCateOfi);
        }
        public DataTable listarEstadosCateOfi()
        {
            return ObjCredito.listarEstadosCateOfi();
        }
        public DataTable grabarPeriodoCateOfi(String cNombre, String cDescripcion, DateTime dFechaInicio, int idEstadoCateOfi, int idUsuReg, DateTime dFechaReg, Boolean lVigente)
        {
            return ObjCredito.grabarPeriodoCateOfi(cNombre, cDescripcion, dFechaInicio, idEstadoCateOfi, idUsuReg, dFechaReg, lVigente);
        }
        public DataTable actualizarPeriodoCateOfi(int idPeriodoCateOfi, String cNombre, String cDescripcion, DateTime dFechaInicio, int idEstadoCateOfi, int idUsuMod, DateTime dFechaMod, Boolean lVigente)
        {
            return ObjCredito.actualizarPeriodoCateOfi(idPeriodoCateOfi, cNombre, cDescripcion, dFechaInicio, idEstadoCateOfi, idUsuMod, dFechaMod, lVigente);
        }




        public DataTable obtenerGrupoOfi()
        {
            return ObjCredito.obtenerGrupoOfi();
        }

        public DataTable obtenerCategoriaOfi()
        {
            return ObjCredito.obtenerCategoriaOfi();
        }

        public DataTable obtenerCategorizacionOfi(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return ObjCredito.obtenerCategorizacionOfi(dFechaDesde, dFechaHasta);
        }

        public DataTable obtenerCategorizacionOfiAut(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return ObjCredito.obtenerCategorizacionOfiAut(dFechaDesde, dFechaHasta);
        }

        public DataTable obtenerGrupoCompCatOfi(int idPeriodo)
        {
            return ObjCredito.obtenerGrupoCompCatOfi(idPeriodo);
        }

        public DataTable GuardarGrupoOficina(int idPeriodo, string xmlGrupoOfi, int idUsuario)
        {
            return ObjCredito.GuardarGrupoOficina(idPeriodo, xmlGrupoOfi, idUsuario);
        }

        public DataTable ListarGrupoOficina(bool lSoloVigentes, int idPeriodoCateOfi)
        {
            return ObjCredito.ListarGrupoOficina(lSoloVigentes, idPeriodoCateOfi);
        }

        public DataTable ListarPeriodoCateOficina(bool lSoloVigentes)
        {
            return ObjCredito.ListarPeriodoCateOficina(lSoloVigentes);
        }

        public DataTable ListarVincGrupoCateOfi(int idPeriodo)
        {
            return ObjCredito.ListarVincGrupoCateOfi(idPeriodo);
        }

        public DataTable GuardarVincGrupoCat(int idPeriodo, string xmlGrupoOfi, int idUsuario)
        {
            return ObjCredito.GuardarVincGrupoCat(idPeriodo, xmlGrupoOfi, idUsuario);
        }

    }
}
