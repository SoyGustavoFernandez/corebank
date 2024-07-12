using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class ClsCNClienteExclusivo
    {
        private ClsADClienteExclusivo objAD = new ClsADClienteExclusivo();

        public DataTable CNObtenerOfertaCliente(int idCli)
        {
            return objAD.ADObtenerOfertaCliente(idCli);
        }

        public DataTable CNObtenerProductos(int idGrupoProducto, string cTipoClienteExclusivo)
        {
            return objAD.ADObtenerProductos(idGrupoProducto, cTipoClienteExclusivo);
        }

        public DataTable CNObtenerOfertaClienteOferta(int idOferta)
        {
            return objAD.ADObtenerOfertaClienteOferta(idOferta);
        }

        public DataTable CNObterneOfertaPersona(string cDocumentoID, int idTipoDocumento)
        {
            return objAD.ADObterneOfertaPersona(cDocumentoID, idTipoDocumento);
        }
        public DataTable CNObterneOfertaPersonaMoneda(string cDocumentoID, int idTipoDocumento)
        {
            return objAD.ADObterneOfertaPersonaMoneda(cDocumentoID, idTipoDocumento);
        }

        public DataTable CNObtenerClasificacionTitularConyuge(string cDocumentoID,int nidTipoDocumento)
        {
            return objAD.ADObtenerClasificacionTitularConyuge(cDocumentoID, nidTipoDocumento);
        }
        public DataTable CNObtenerDatosTipContacto()
        {
            return objAD.ADObtenerDatosTipContacto();
        }

        public DataTable CNObtenerDatosDetRegContacto()
        {
            return objAD.ADObtenerDatosDetRegContacto();
        }

        public DataTable CNGuardarDatosDetRegContacto(int idTipoContacto, int idDetTipoContacto, string cDetalleOtros, string dFechaSel, int idUsuario, int idEstablecimiento, int idAgencia, int idCli, string cDocumentoId)
        {
            return objAD.ADGuardarDatosDetRegContacto(idTipoContacto, idDetTipoContacto, cDetalleOtros, dFechaSel, idUsuario, idEstablecimiento, idAgencia, idCli, cDocumentoId);
        }

        public DataTable CNReporteRegistroContacto(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objAD.ADReporteRegistroContacto(dFechaDesde, dFechaHasta);
        }

        public DataTable CNReporteDesembolsoCampNav(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objAD.ADReporteDesembolsoCampNav(dFechaDesde, dFechaHasta);
        }

        public DataTable CNVerificarInformacionContacto(int idCliente, string cDocumentoID)
        {
            return objAD.ADVerificarInformacionContacto(idCliente, cDocumentoID);
        }

        public DataTable CNRPTDesembolsoCampEscolar(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objAD.ADRPTDesembolsoCampEscolar(dFechaDesde, dFechaHasta);
        }

        public clsRespuestaServidor CNRegistarBusqueda(string cDocumentoID)
        {
            DataTable dtRespuesta = this.objAD.ADRegistrarBusqueda(cDocumentoID);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public DataTable CNConsultarBusqueda(string cDocumentoID)
        {
            return this.objAD.ADConsultarBusqueda(cDocumentoID);
        }

        public DataTable CNAsesorAsignado(int idCli, int idEstablecimiento)
        {
            return this.objAD.ADOAsesorAsignado(idCli, idEstablecimiento);
        }
        public List<clsClienteOfertaCredirapPro> CNObtenerOfertaCredirapPro(string cDocumento)
        {
            return this.objAD.ADObtenerOfertaCredirapPro(cDocumento);
        }
    }
}
