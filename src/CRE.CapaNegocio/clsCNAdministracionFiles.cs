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
    public class clsCNAdministracionFiles
    {
        public clsADAdministracionFiles objADAdministracionFiles;

        public clsCNAdministracionFiles()
        {
            objADAdministracionFiles = new clsADAdministracionFiles();
        }

        public clsCNAdministracionFiles(bool lWS)
        {
            objADAdministracionFiles = new clsADAdministracionFiles(lWS);
        }

        public DataTable ListarTiposDocumentosEvaluacion(int idSolicitud)
        {
            return objADAdministracionFiles.ListarTiposDocumentosEvaluacion(idSolicitud);
        }

        public DataTable insertFilesEvaluacion(string xmlFiles, int idSolicitud)
        {
            return objADAdministracionFiles.insertFilesEvaluacion(xmlFiles, idSolicitud);
        }

        public DataTable insertarDocumentosEvaluacion(int idSolicitud, int idTipoDoc, string cNombreDoc, string vDocBase, byte[] vBinaryDocBase, string cExtencion)
        {
            return objADAdministracionFiles.insertarDocumentosEvaluacion(idSolicitud, idTipoDoc, cNombreDoc, vDocBase, vBinaryDocBase, cExtencion);
        }

        public DataTable getArchivoSolicitud(int idSolicitud, int idTipoDoc)
        {
            return objADAdministracionFiles.getArchivoSolicitud(idSolicitud, idTipoDoc);
        }

        public DataSet getTipoGrupoArchivo(int idSolicitud, int idUsuario)
        {
            return objADAdministracionFiles.getTipoGrupoArchivo(idSolicitud, idUsuario);
        }
        public DataSet getTipoGrupoArchivoCli(int idCli)
        {
            return objADAdministracionFiles.getTipoGrupoArchivoCli(idCli);
        }


        public DataSet ObtenerTipoGrupoArchivoCheckList(int idSolicitud, bool lGruposSolidario)
        {
            return objADAdministracionFiles.ObtenerTipoGrupoArchivoCheckList(idSolicitud, lGruposSolidario);
        }

        public DataTable DtObtenerTipoGrupoArchivoCheckList(int idSolicitud, bool lGruposSolidario)
        {
            return objADAdministracionFiles.DtObtenerTipoGrupoArchivoCheckList(idSolicitud, lGruposSolidario);
        }

        public DataSet getVoucherArchivoPrepago(int idUsuario, int nNroCuenta)
        {
            return objADAdministracionFiles.getVoucherArchivoPrepago(idUsuario, nNroCuenta);
        }

        public DataTable cargarVoucherArchivo(string cArchivo, string cExtension, int idUsuario, int idSolicitudTramite, byte[] bArchivoBinary)
        {
            return objADAdministracionFiles.cargarVoucherArchivo(cArchivo, cExtension, idUsuario, idSolicitudTramite, bArchivoBinary);
        }

        public DataTable mostrarVoucherArchivo(int idSolicitud)
        {
            return objADAdministracionFiles.mostrarVoucherArchivo(idSolicitud);
        }

        public DataTable cargarArchivo(int idSolicitud, int iddescTipoDoc, int idTipoArchivo, string cArchivo, byte[] bArchivoBinary, string cExtension, int idUsuario)
        {
            return objADAdministracionFiles.cargarArchivo(idSolicitud, iddescTipoDoc, idTipoArchivo, cArchivo, bArchivoBinary, cExtension, idUsuario);
        }
        public DataTable cargarArchivoPolPriv(int idSolicitud, int iddescTipoDoc, int idTipoArchivo, string cArchivo, byte[] bArchivoBinary, string cExtension, int idUsuario, int idCli)
        {
            return objADAdministracionFiles.cargarArchivoPolPriv(idSolicitud, iddescTipoDoc, idTipoArchivo, cArchivo, bArchivoBinary, cExtension, idUsuario, idCli);
        }

        public DataTable CNObtenerArchivoEscaneado(int idSolicitud, int idTipoArchivo)
        {
            return objADAdministracionFiles.getArchivoEscaneado(idSolicitud, idTipoArchivo);
        }

        public DataTable obtenerDatosSolicitud(int idSolicitud)
        {
            return objADAdministracionFiles.obtenerDatosSolicitud(idSolicitud);
        }

        public DataSet listarSolicitudesCreditoObs(int idUsuario)
        {
            return objADAdministracionFiles.listarSolicitudesCreditoObs(idUsuario);
        }

        public DataSet listarDetallesCreditoObs(int idSolicitud, int idTipoArchivo)
        {
            return objADAdministracionFiles.listarDetallesCreditoObs(idSolicitud, idTipoArchivo);
        }

        public DataTable guardarRegistroSolCredObs(int idUsuarioReg, int idSolicitud, int idTipoSolicitudObs, int idTipoArchivo, int idEstadoCreditoObs, int idRegistroSolCredObs, string cDetalleObservacion, int idDetalleSolCredObs)
        {
            return objADAdministracionFiles.guardarRegistroSolCredObs(idUsuarioReg, idSolicitud, idTipoSolicitudObs, idTipoArchivo, idEstadoCreditoObs, idRegistroSolCredObs, cDetalleObservacion, idDetalleSolCredObs);
        }

        public DataTable ListarZonaVigentes()
        {
            return objADAdministracionFiles.ListarZonaVigentes();
        }

        public DataTable ListarAgenciaPorListaRegion(string cXmlRegion)
        {
            return objADAdministracionFiles.ListarAgenciaPorListaRegion(cXmlRegion);
        }

        public DataTable ListarEStablecimientoPorListaAgencia(string cXmlAgencias)
        {
            return objADAdministracionFiles.ListarEStablecimientoPorListaAgencia(cXmlAgencias);
        }

        public DataSet listarSolicitudesCreditoObsPendientes(string cXmlCheckList, bool lLista)
        {
            return objADAdministracionFiles.listarSolicitudesCreditoObsPendientes(cXmlCheckList, lLista);
        }

        public DataTable EstadoCreditoObs()
        {
            return objADAdministracionFiles.EstadoCreditoObs();
        }

        public DataTable CNRptSolicitudesCreditosObservados(string cXmlEstablecimientos, int idEstadoCreditoObs, DateTime dFechaInicio, DateTime dFechaFin, bool lHistorial)
        {
            return objADAdministracionFiles.CNRptSolicitudesCreditosObservados(cXmlEstablecimientos, idEstadoCreditoObs, dFechaInicio, dFechaFin, lHistorial);
        }

        public DataTable ListarPerfilVBObservaChecklist()
        {
            return objADAdministracionFiles.ListarPerfilVBObservaChecklist();
        }

        public DataTable ListarPerfilAbsuelveChecklist()
        {
            return objADAdministracionFiles.ListarPerfilAbsuelveChecklist();
        }

        public bool enPreAprobacion(int idSolicitud)
        {
            DataTable dtResult = objADAdministracionFiles.obtenerEstadoSolicitud(idSolicitud);
            if (dtResult.Rows.Count == 0) return false;
            int idEstado = Convert.ToInt32(dtResult.Rows[0]["idEstado"].ToString());
            var estadosPreAprobacion = new List<int>() { 0, 1, 13 };
            return estadosPreAprobacion.Contains(idEstado);
        }

        public DataSet CNObtenerTipoGrupoArchivoTasa(int idSolicitud)
        {
            return objADAdministracionFiles.ADObtenerTipoGrupoArchivoTasa(idSolicitud);
        }
        public DataSet CNObtenerTipoGrupoArchivoTasaPost(int idSolicitud)
        {
            return objADAdministracionFiles.ADObtenerTipoGrupoArchivoTasaPost(idSolicitud);
        }
    }
}
