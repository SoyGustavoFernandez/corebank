using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class ClsADClienteExclusivo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADObtenerOfertaCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_BuscarOfertasClienteExclusivo_SP", idCli);
        }

        public DataTable ADObtenerProductos(int idGrupoProducto, string cTipoClienteExclusivo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerProductosClienteExclusivo_SP", idGrupoProducto, cTipoClienteExclusivo);
        }

        public DataTable ADObtenerOfertaClienteOferta(int idOferta)
        {
            return objEjeSp.EjecSP("CRE_BuscarOfertasClienteExclusivoxIdOferta_SP", idOferta);
        }

        public DataTable ADObterneOfertaPersona(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_BuscarOfertaClientexDocumentoID_SP", cDocumentoID, idTipoDocumento);
        }
        public DataTable ADObterneOfertaPersonaMoneda(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_BuscarOfertaClientMoneda_SP", cDocumentoID, idTipoDocumento);
        }
        public DataTable ADObtenerClasificacionTitularConyuge (string cDocumentoID,int nidTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_CalificacionTitularConyuge_sp", cDocumentoID, nidTipoDocumento);
        }


        public DataTable ADObtenerDatosTipContacto()
        {
            return objEjeSp.EjecSP("CRE_DevuelveTipContacto_SP");
        }

        public DataTable ADObtenerDatosDetRegContacto()
        {
            return objEjeSp.EjecSP("CRE_DevuelveDetRegContacto_SP");
        }

        public DataTable ADGuardarDatosDetRegContacto(int idTipoContacto, int idDetTipoContacto, string cDetalleOtros, string dFechaSel, int idUsuario, int idEstablecimiento, int idAgencia, int idCli, string cDocumentoId)
        {
            return objEjeSp.EjecSP("CRE_GuardarDetRegContacto_SP", idTipoContacto, idDetTipoContacto, cDetalleOtros, dFechaSel, idUsuario, idEstablecimiento, idAgencia, idCli, cDocumentoId);
        }

        public DataTable ADReporteRegistroContacto(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CRE_ReporteDetRegContacto_SP", dFechaDesde, dFechaHasta);
        }

        public DataTable ADReporteDesembolsoCampNav(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CRE_ReporteCliDesembolsadosCampNav_SP", dFechaDesde, dFechaHasta);
        }

        public DataTable ADVerificarInformacionContacto(int idCliente, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_VerificarInfoContactoOferta_SP", idCliente, cDocumentoID);
        }

        public DataTable ADRPTDesembolsoCampEscolar(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSp.EjecSP("CRE_RPTDesembolsosCampEscolar_SP", dFechaDesde, dFechaHasta);
        }

        public DataTable ADRegistrarBusqueda(string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_RegistrarBusqueda_SP", cDocumentoID);
        }

        public DataTable ADConsultarBusqueda(string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_ConsultarBusqueda_SP", cDocumentoID);
        }

        public DataTable ADOAsesorAsignado(int idCli, int idEstablecimiento)
        {
            return objEjeSp.EjecSP("CRE_obtenerAsesorAsignado_SP", idCli, idEstablecimiento);
        }

        public List<clsClienteOfertaCredirapPro> ADObtenerOfertaCredirapPro(string cDocumento)
        {
            DataTable dtClienteOfertaPro = this.objEjeSp.EjecSP("CRE_ObtenerOfertaCredirappPro_SP", cDocumento);

            return (dtClienteOfertaPro.Rows.Count > 0) ?
                dtClienteOfertaPro.ToList<clsClienteOfertaCredirapPro>() as List<clsClienteOfertaCredirapPro> :
                new List<clsClienteOfertaCredirapPro>();
        }
    }
}
