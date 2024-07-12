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
     
    public class clsCNSeguros
    {
        clsADSeguros clsSeguros = new clsADSeguros();

        public DataTable LisSeguro()
        {
            DataTable dtSeguros =  clsSeguros.LisSeguro();
            return dtSeguros;
        }

        public DataTable obtenerPrecioPlanSeguro(int idTipoPlan, int idSolicitud)
        {
            DataTable dtMonto = clsSeguros.ObtenerPrecio(idTipoPlan, idSolicitud);
            return dtMonto;
        }

        public DataTable ListarSeguros(int idCli)
        {
            return clsSeguros.ListarSeguros(idCli);
        }

        public List<clsSegurosNoPermitidos> CNListaSegurosNoPermitidos()
        {
            return clsSeguros.CNListaSegurosNoPermitidos();
        }
        public List<clsSegurosDesmarcados> CNListaSegurosDesmarcados(int idSolicitud)
        {
            return clsSeguros.CNListaSegurosDesmarcados(idSolicitud);
        }

        public DataTable RPTConsultaSegurosDesmarcados(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return clsSeguros.RPTConsultaSegurosDesmarcados(dFechaDesde, dFechaHasta);
        }

        public DataTable CNObtenerDatosRPTSeguimientoSeguroOncologico(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return clsSeguros.ADObtenerDatosRPTSeguimientoSeguroOncologico(dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable CNValidarPermisosRPTOncologico(int idPerfil)
        {
            return clsSeguros.ADValidarPermisosRPTOncologico(idPerfil);
        }

        public List<clsPolizaSeguro> CNObtenerPolizaSeguro()
        {
            DataTable dtPolizaSeguro = clsSeguros.ADObtenerPolizaSeguro();

            return (dtPolizaSeguro.Rows.Count > 0) ? dtPolizaSeguro.ToList<clsPolizaSeguro>() as List<clsPolizaSeguro> : new List<clsPolizaSeguro>();
        }
    }
}
