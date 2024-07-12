using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using System.Xml.Linq;
using GEN.AccesoDatos;

namespace CRE.AccesoDatos
{
    public class clsADControlExp
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        //Crear Método para ejecutar SP
        public DataTable ADListDetalleExp(int idCliente, int idTipoOpeExpediente)
        {
            return objEjeSp.EjecSP("CRE_ListaDetalleExpediente_sp", idCliente, idTipoOpeExpediente);
        }

        public DataTable ADBuscaDetalleExp(int idCliente)
        {
            return objEjeSp.EjecSP("CRE_BuscaDetalleExpediente_sp", idCliente);
        } 

        public DataTable ADRegistraExpediente(string XML)
        {
            return objEjeSp.EjecSP("CRE_RegistraSolicExpediente_sp", XML);
        }

        public DataTable ADBuscaExpediente(int idCliente, int idTipoOpeExp)
        {
            return objEjeSp.EjecSP("CRE_BuscaExpediente_sp", idCliente, idTipoOpeExp);
        }

        public DataTable ADBuscaSolExpediente(int idAgencia, int idCliente, int Perfil)
        {
            return objEjeSp.EjecSP("CRE_BuscaSolExpPendiente_sp", idAgencia, idCliente, Perfil);
        }

        public DataTable ADBuscaExpEntregado(int idUsuario, int idAgencia,int Perfil)
        {
            return objEjeSp.EjecSP("CRE_BuscaSolExpEntregado_sp", idUsuario, idAgencia, Perfil);
        }

        public DataTable ADBuscaExpRecep(int idAgencia, int idCliente)
        {
            return objEjeSp.EjecSP("CRE_BuscaSolExpRecepcionado_sp", idAgencia, idCliente);
        }

        public DataTable ADActualizaEstadoExp(string XML, string Estado, int Perfil, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ActEstadoExpediente_sp", XML, Estado, Perfil, idUsuario);
        }

        public DataTable ADListaCondExpediente()
        {
            return objEjeSp.EjecSP("CRE_ListaCondicionExpediente_sp");
        }
        public DataTable ADListaCondExpedienteXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinCondicionExpediente");
        }

        public DataTable ADTipoFolioExpediente()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoFolioExp_sp");
        }
        public DataTable ADInsertDetalleExpediente(string XML)
        {
            return objEjeSp.EjecSP("CRE_RegDetalleExpediente_sp", XML);
        }
        public DataTable ADListaEstadoExpediente()
        {
            return objEjeSp.EjecSP("CRE_ListaEstadoExpediente_sp");
        }
        public DataTable ADBusquedaExpediente(int idEstadoExp, int idAgencia, int idUsuario, DateTime dfechaRegIni, DateTime dfechaRegFin)
        {
            return objEjeSp.EjecSP("CRE_BusquedaExpediente_sp", idEstadoExp, idAgencia, idUsuario, dfechaRegIni, dfechaRegFin);
        }
        public DataTable ADBuscaExpCliente(int idCliente)
        {
            return objEjeSp.EjecSP("CRE_BuscaExpedienteCliente_sp", idCliente);
        }
        public DataTable ADRegistraTrasladoExp(string XML, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_RegistraTrasladoExp_sp", XML, idPerfil);
        }
        public DataTable ADBuscaExpTrasladados(int idCliente)
        {
            return objEjeSp.EjecSP("CRE_BuscaTrasladoExp_sp", idCliente);
        }
        //reporte de arqueo de expediente
        public DataTable ADArqueoExpediente(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_RptArqueoExpediente_SP", idAgencia);
        }
        //reporte de arqueo de expediente por cliente
        public DataTable ADArqueoExpCliente(int idCli, int idTipoOpeExp)
        {
            return objEjeSp.EjecSP("RPT_ArqueoExpCliente_SP", idCli, idTipoOpeExp);
        }
        public DataTable ADListaDocumentosExpedientes(int idTipoOpeExp = 0)
        {
            return objEjeSp.EjecSP("CRE_ListarDocumentosExpedientes_SP", idTipoOpeExp);
        }
        public DataTable ADListaTipoExpediente()
        {
            return objEjeSp.EjecSP("CRE_ListarTipoOperacionExpediente_SP");
        }
        public DataTable ADListarMotivosSolicitudExpediente(int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ListarMotivoSolicitudExpediente_SP", idPerfil);
        }
        public DataTable ADListarExpedientePorTipoOperacion(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ListarExpedientesPorTipoOperacion_SP", idCli);
        }
        public DataTable ADListaTipoDocumentoExpediente(int idTipoDocumentoExp)
        {
            return objEjeSp.EjecSP("CRE_RetornarTipoDocumentoExp_SP", idTipoDocumentoExp);
        }
        public DataTable ADListarPerfilesMotivoSolExp()
        {
            return objEjeSp.EjecSP("CRE_ListarPerfilesMotivoSolExp_SP");
        }
        public DataTable ADRptExpedientesVencidosDevolucion(int idAgencia, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("CRE_RptExpedientesVencidosDevolucion_SP", idAgencia, dFechaSis);
        }
        public DataTable ADRptPagaresParaArqueo(DateTime dFechaInicio, DateTime dFechaFin, int idAgencia, int idMoneda, int idFiltro, int nPagare)
        {
            return objEjeSp.EjecSP("CRE_RptPagaresArqueo_SP", dFechaInicio, dFechaFin, idAgencia, idMoneda, idFiltro, nPagare);
        }

        public DataTable ADRptReporteCreditoColaborador(int idEstado, DateTime dFechaInicio, DateTime dFechaFin, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_RptReporteCreditoColaborador_SP", idEstado, dFechaInicio, dFechaFin, idAgencia);
        }
        
        public DataTable ADBuscarExpedienteFiltros(int idAgencia, int idEstado, int idTipoOpeExp, DateTime dFechaInicio, DateTime dFechaFin, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("CRE_ResumenBusquedaExpediente_SP", idAgencia, idEstado, idTipoOpeExp, dFechaInicio, dFechaFin, dFechaSis);
        }
        public DataTable ADHistorialExpediente(int idCli, int idTipoOperacion, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("CRE_HistorialBusquedaExpediente_SP", idCli, idTipoOperacion, dFechaSis);
        }
        public DataTable ADBuscarExpedientePorCliente(int idCli, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("CRE_ResumenExpedientePorCliente_SP", idCli, dFechaSis);
        }
        public DataTable ADRptHistorialExpedientes(int idCli, int idTipoOpeExp)
        {
            return objEjeSp.EjecSP("CRE_RptHistorialExpediente_SP", idCli, idTipoOpeExp);
        }
        public DataTable ADClienteExpediente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ClienteExpediente_SP", idCli);
        }
        public DataTable ADClienteParaImpresionLomoExpediente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ClientesParaImpresionLomosExpedientes_SP", idCli);
        }
        public DataTable ADBuscaExpeEntreTipoOpe(int idCli, int idTipoOpe)
        {
            return objEjeSp.EjecSP("CRE_BuscaExpeEntreTipoOpe_SP", idCli, idTipoOpe);
        }
        public DataTable ADValidarSolExpPendUsuario(int idUsuario, int idCli, int idTipoOpe)
        {
            return objEjeSp.EjecSP("CRE_ValidarSolExpPendUsuario_SP", idUsuario, idCli, idTipoOpe);
        }

        #region CheckList

        public DataTable ADGuardarListaDocsXProducto(int idProducto, string cXml)
        {
            return objEjeSp.EjecSP("CRE_GuardarCheckDocsPorProducto_SP", idProducto, cXml); 
        }

        public DataTable ADObtenerListaDocObligatorios(int idTipoPersona, int idProducto, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerListaDocObligatorios_SP", idTipoPersona, idProducto, idSolicitud);
        }

        public DataTable ADGuardaDocTieneSolicitud(int idSolicitud, string cXml)
        {
            return objEjeSp.EjecSP("CRE_GuardaDocTieneSolicitud_SP", idSolicitud, cXml);
        }

        public DataTable ADListaDocsPorProducto(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ListaDocsPorProducto_SP", idProducto);
        }

        public DataTable ADValidarListaDocsEval(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidaDocumentoObligatoriosEval_SP", idSolicitud);
        }
        #endregion


        #region GuardarExpedientes
        public DataTable ADListarGrupoExpediente(int idSolicitud, string cTipoSolicitud)
        {
            return objEjeSp.EjecSP("GEN_ListarGrupoExpediente_SP", idSolicitud, cTipoSolicitud);
        }
        #endregion

    }
}
