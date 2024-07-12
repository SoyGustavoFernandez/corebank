using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsADAdministracionFiles
    {
        IntConexion objEjeSp;

        public clsADAdministracionFiles()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAdministracionFiles(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ListarTiposDocumentosEvaluacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarTiposDocEvaluacion_SP", idSolicitud);
        }

        public DataTable insertFilesEvaluacion(string xmlFiles, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_guardarDocumentosEvaluacion_SP", xmlFiles, idSolicitud);
        }

        public DataTable insertarDocumentosEvaluacion(int idSolicitud, int idTipoDoc, string cNombreDoc, string vDocBase, byte[] vBinaryDocBase, string cExtencion)
        {
            return objEjeSp.EjecSP("CRE_InsertarDocumentoEvaluacion_SP", idSolicitud, idTipoDoc, cNombreDoc, vDocBase, vBinaryDocBase, cExtencion);
        }

        public DataTable getArchivoSolicitud(int idSolicitud, int idTipoDoc)
        {
            return objEjeSp.EjecSP("CRE_ObtenerArchivoSolicitud_SP", idSolicitud, idTipoDoc);
        }

        public DataSet getTipoGrupoArchivo(int idSolicitud, int idUsuario, bool lChecklist = false)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerTipogrupoArchivo_SP", idSolicitud, idUsuario, lChecklist);
        }
        public DataSet getTipoGrupoArchivoCli(int idcli)
        {
            return objEjeSp.DSEjecSP("GEN_getTipoGrupoArchivoCli_SP", idcli);
        }


        public DataSet ObtenerTipoGrupoArchivoCheckList(int idSolicitud, bool lGruposSolidario)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerTipoGrupoArchivoCheckList_SP", idSolicitud, lGruposSolidario);
        }

        public DataTable DtObtenerTipoGrupoArchivoCheckList(int idSolicitud, bool lGruposSolidario)
        {
            return objEjeSp.EjecSP("CRE_ObtenerTipoGrupoArchivoCheckList_SP", idSolicitud, lGruposSolidario);
        }


        public DataSet getVoucherArchivoPrepago(int idUsuario, int nNroCuenta)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerVoucherArchivoPrepago_SP", idUsuario, nNroCuenta);
        }

        public DataTable cargarVoucherArchivo(string cArchivo, string cExtension, int idUsuario, int idSolicitudTramite, byte[] bArchivoBinary)
        {
            return objEjeSp.EjecSP("CRE_CargarVoucherArchivo_SP", cArchivo, cExtension, idUsuario, idSolicitudTramite, bArchivoBinary);
        }

        public DataTable mostrarVoucherArchivo(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_MostrarVoucherArchivo_SP", idSolicitud);
        }

        public DataTable cargarArchivo(int idSolicitud, int idDescTipoDoc, int idTipoArchivo, string cArchivo, byte[] bArchivoBinary, string cExtension, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_CargarArchivoExpediente_SP", idSolicitud, idDescTipoDoc, idTipoArchivo, cArchivo, bArchivoBinary, cExtension, idUsuario);
        }
        public DataTable cargarArchivoPolPriv(int idSolicitud, int idDescTipoDoc, int idTipoArchivo, string cArchivo, byte[] bArchivoBinary, string cExtension, int idUsuario, int idCli)
        {
            return objEjeSp.EjecSP("CRE_CargarArchivoExpedientePolitPriv_SP", idSolicitud, idDescTipoDoc, idTipoArchivo, cArchivo, bArchivoBinary, cExtension, idUsuario, idCli);
        }
        public DataTable getArchivoEscaneado(int idSolicitud, int idTipoArchivo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerArchivoEscaneado_SP", idSolicitud, idTipoArchivo);
        }

        public DataTable obtenerDatosSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosSolicitudArchivo_SP", idSolicitud);
        }

        public DataTable obtenerEstadoSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerEstadoSolicitud_SP", idSolicitud);
        }
        public DataSet listarSolicitudesCreditoObs(int idUsuario)
        {
            return objEjeSp.DSEjecSP("CRE_ListarSolicitudesCreditoObs_SP", idUsuario);
        }
        public DataSet listarDetallesCreditoObs(int idSolicitud, int idTipoArchivo)
        {
            return objEjeSp.DSEjecSP("CRE_ListarDetallesCreditoObs_SP", idSolicitud, idTipoArchivo);
        }

        public DataTable guardarRegistroSolCredObs(int idUsuarioReg, int idSolicitud, int idTipoSolicitudObs, int idTipoArchivo, int idEstadoCreditoObs, int idRegistroSolCredObs, string cDetalleObservacion, int idDetalleSolCredObs)
        {
            return objEjeSp.EjecSP("CRE_GuardarRegistroSolCredObs_SP", idUsuarioReg, idSolicitud, idTipoSolicitudObs, idTipoArchivo, idEstadoCreditoObs, idRegistroSolCredObs, cDetalleObservacion, idDetalleSolCredObs);
        }

        public DataTable ListarZonaVigentes()
        {
            return objEjeSp.EjecSP("ADM_ListarZonaVigentes_SP");
        }

        public DataTable ListarAgenciaPorListaRegion(string cXmlRegion)
        {
            return objEjeSp.EjecSP("CRE_RetornaAgenciaPorListaRegion_SP", cXmlRegion);
        }

        public DataTable ListarEStablecimientoPorListaAgencia(string cXmlAgencias)
        {
            return objEjeSp.EjecSP("CRE_RetornaEstablecimientoPorListaAgencia_SP", cXmlAgencias);
        }

        public DataSet listarSolicitudesCreditoObsPendientes(string cXmlCheckList, bool lLista)
        {
            return objEjeSp.DSEjecSP("CRE_ListarSolicitudCredObsPendiente_SP", cXmlCheckList, lLista);
        }

        public DataTable EstadoCreditoObs()
        {
            return objEjeSp.EjecSP("CRE_RetornaEstadoCreditoObs_SP");
        }

        public DataTable ListarPerfilVBObservaChecklist()
        {
            return objEjeSp.EjecSP("CRE_ListaPerfilVBObservaChecklist");
        }

        public DataTable ListarPerfilAbsuelveChecklist()
        {
            return objEjeSp.EjecSP("CRE_ListaPerfilAbsuelveChecklist");
        }

        public DataTable CNRptSolicitudesCreditosObservados(string cXmlEstablecimientos, int idEstadoCreditoObs, DateTime dFechaInicio, DateTime dFechaFin, bool lHistorial)
        {
            return objEjeSp.EjecSP("CRE_RptSolicitudesCreditosObservados_SP", cXmlEstablecimientos, idEstadoCreditoObs, dFechaInicio, dFechaFin, lHistorial);
        }
        public DataSet ADObtenerTipoGrupoArchivoTasa(int idSolicitud)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerTipoArchivoTasa_SP", idSolicitud);
        }
        public DataSet ADObtenerTipoGrupoArchivoTasaPost(int idSolicitud)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerTipoArchivoTasaPost_SP", idSolicitud);
        }
    }
}
