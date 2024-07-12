using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNControlExp
    {
        public clsADControlExp ControExpediente = new clsADControlExp();

        public DataTable CNListDetalleExp(Int32 idCliente, int idTipoOpeExpediente)
        {
            return ControExpediente.ADListDetalleExp(idCliente, idTipoOpeExpediente);
        }

        public DataTable CNBuscaDetalleExp(Int32 idCliente)
        {
            return ControExpediente.ADBuscaDetalleExp(idCliente);
        } 

        public DataTable CNRegistroSolExp(string  XML)
        {
            return ControExpediente.ADRegistraExpediente(XML);
        }

        public DataTable CNBuscaExp(Int32 idCliente, int idTipoOpeExp)
        {
            return ControExpediente.ADBuscaExpediente(idCliente, idTipoOpeExp);
        }

        public DataTable CNBuscaSolExpediente(int idAgencia, int idCliente, int Perfil)
        {
            return ControExpediente.ADBuscaSolExpediente(idAgencia, idCliente, Perfil);
        }

        public DataTable CNBuscaExpEntregado(int idUsuario, int idAgencia, int Perfil)
        {
            return ControExpediente.ADBuscaExpEntregado(idUsuario, idAgencia, Perfil);
        }

        public DataTable CNBuscaExpRecep(int idAgencia, int idCliente)
        {
            return ControExpediente.ADBuscaExpRecep(idAgencia, idCliente);
        } 

        public DataTable CNActEstadoExp(string XML, string Estado, int Perfil, int idUsuario)
        {
            return ControExpediente.ADActualizaEstadoExp(XML, Estado, Perfil, idUsuario);
        }

        public DataTable CNListaCondExpediente()
        {
           // return ControExpediente.ADListaCondExpediente();
            return ControExpediente.ADListaCondExpedienteXML();
        }

        public DataTable CNTipoFolioExpediente()
        {
            return ControExpediente.ADTipoFolioExpediente();
        }
        public DataTable CNInsDetalleExpediente(string XML)
        {
            return ControExpediente.ADInsertDetalleExpediente(XML);
        }
        public DataTable CNListaEstadoExpediente()
        {
            return ControExpediente.ADListaEstadoExpediente();
        }
        public DataTable CNBusquedaExpediente(int idEstadoExp, int idAgencia, int idUsuario, DateTime dfechaRegIni, DateTime dfechaRegFin)
        {
            return ControExpediente.ADBusquedaExpediente(idEstadoExp, idAgencia, idUsuario, dfechaRegIni, dfechaRegFin);
        }
        public DataTable CNBuscaExpCliente(int idCliente)
        {
            return ControExpediente.ADBuscaExpCliente(idCliente);
        }
        public DataTable CNRegistraTrasladoExp(string XML, int idPerfil)
        {
            return ControExpediente.ADRegistraTrasladoExp(XML, idPerfil);
        }
        public DataTable CNBuscaExpTrasladados(int idCliente)
        {
            return ControExpediente.ADBuscaExpTrasladados(idCliente);
        }
        //reporte de arqueo de expediente
        public DataTable CNArqueoExpediente(int idAgencia)
        {
            return ControExpediente.ADArqueoExpediente(idAgencia);
        }
        //reporte de arqueo de expediente
        public DataTable CNArqueoExpCliente(int idCli, int idTipoOpeExp)
        {
            return ControExpediente.ADArqueoExpCliente(idCli, idTipoOpeExp);
        }
        public DataTable CNListaDocumentosExpedientes(int idTipoOpeExp = 0)
        {
            return ControExpediente.ADListaDocumentosExpedientes(idTipoOpeExp);
        }
        public DataTable CNListaTipoExpediente()
        {
            return ControExpediente.ADListaTipoExpediente();
        }
        public DataTable CNListarMotivosSolicitudExpediente(int idPerfil)
        {
            return ControExpediente.ADListarMotivosSolicitudExpediente(idPerfil);
        }
        public DataTable CNListarExpedientePorTipoOperacion(int idCli)
        {
            return ControExpediente.ADListarExpedientePorTipoOperacion(idCli);
        }
        public DataTable CNListaTipoDocumentoExpediente(int idTipoDocumentoExp)
        {
            return ControExpediente.ADListaTipoDocumentoExpediente(idTipoDocumentoExp);
        }
        // Lista los los perfiles que fueron relacionados con motivossolicitud expediente
        public DataTable CNListarPerfilesMotivoSolExp()
        {
            return ControExpediente.ADListarPerfilesMotivoSolExp();
        }
        // lista
        public DataTable CNRptExpedientesVencidosDevolucion(int idAgencia, DateTime dFechaSis)
        {
            return ControExpediente.ADRptExpedientesVencidosDevolucion(idAgencia, dFechaSis);
        }
        public DataTable CNRptPagaresParaArqueo(DateTime dFechaInicio, DateTime dFechaFin, int idAgencia, int idMoneda, int idFiltro, int nPagare)
        {
            return ControExpediente.ADRptPagaresParaArqueo(dFechaInicio, dFechaFin, idAgencia, idMoneda, idFiltro, nPagare);
        }

        public DataTable CNRptReporteCreditoColaborador(int idEstado, DateTime dFechaInicio, DateTime dFechaFin, int idAgencia)
        {
            return ControExpediente.ADRptReporteCreditoColaborador(idEstado, dFechaInicio, dFechaFin, idAgencia);
        }

        public DataTable CNBuscarExpedienteFiltros(int idAgencia, int idEstado, int idTipoOpeExp, DateTime dFechaInicio, DateTime dFechaFin, DateTime dFechaSis)
        {
            return ControExpediente.ADBuscarExpedienteFiltros(idAgencia, idEstado, idTipoOpeExp, dFechaInicio, dFechaFin, dFechaSis);
        }

        public DataTable CNHistorialExpediente(int idCli, int idTipoOperacion, DateTime dFechaSis)
        {
            return ControExpediente.ADHistorialExpediente(idCli, idTipoOperacion, dFechaSis);
        }

        public DataTable CNBuscarExpedientePorCliente(int idCli, DateTime dFechaSis)
        {
            return ControExpediente.ADBuscarExpedientePorCliente(idCli, dFechaSis);
        }
        public DataTable CNRptHistorialExpedientes(int idCli, int idTipoOpeExp)
        {
            return ControExpediente.ADRptHistorialExpedientes(idCli, idTipoOpeExp);
        }
        public DataTable CNClienteExpediente(int idCli)
        {
            return ControExpediente.ADClienteExpediente(idCli);
        }
        public DataTable CNClienteParaImpresionLomoExpediente(int idCli)
        {
            return ControExpediente.ADClienteParaImpresionLomoExpediente(idCli);
        }
        public DataTable CNBuscaExpeEntreTipoOpe(int idCli, int idTipoOpe)
        {
            return ControExpediente.ADBuscaExpeEntreTipoOpe(idCli, idTipoOpe);
        }
        public DataTable CNValidarSolExpPendUsuario(int idUsuario, int idCli, int idTipoOpe)
        {
            return ControExpediente.ADValidarSolExpPendUsuario(idUsuario, idCli, idTipoOpe);
        }

        #region CheckList
        
        public DataTable CNGuardarListaDocsXProducto(int idProducto, string cXml)
        {
            return ControExpediente.ADGuardarListaDocsXProducto(idProducto, cXml);
        }

        public DataTable CNObtenerListaDocObligatorios(int idTipoPersona, int idProducto, int idSolicitud)
        {
            return ControExpediente.ADObtenerListaDocObligatorios(idTipoPersona, idProducto, idSolicitud);
        }

        public DataTable CNGuardaDocTieneSolicitud(int idSolicitud, string cXml)
        {
            return ControExpediente.ADGuardaDocTieneSolicitud(idSolicitud, cXml);
        }

        public DataTable CNListaDocsPorProducto(int idProducto)
        {
            return ControExpediente.ADListaDocsPorProducto(idProducto);
        }

        public DataTable CNValidarListaDocsEval(int idSolicitud)
        {
            return ControExpediente.ADValidarListaDocsEval(idSolicitud);
        }
        #endregion

        #region GuardarExpedientes
        public DataTable CNListarGrupoExpediente(int idSolicitud, string cTipoSolicitud)
        {
            return ControExpediente.ADListarGrupoExpediente(idSolicitud, cTipoSolicitud);
        }
        #endregion
    }
}
