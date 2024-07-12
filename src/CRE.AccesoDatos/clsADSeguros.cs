using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos; 
using EntityLayer;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsADSeguros
    {
        public List<clsSegurosNoPermitidos> CNListaSegurosNoPermitidos()
        {
            DataTable dtRes = new clsGENEjeSP().EjecSP("CRE_ListaSegurosPermitidosDesmarcar_SP");
            return DataTableToList.ConvertTo<clsSegurosNoPermitidos>(dtRes) as List<clsSegurosNoPermitidos>;
        }

        public List<clsSegurosDesmarcados> CNListaSegurosDesmarcados(int idSolicitud)
        {
            DataTable dtRes = new clsGENEjeSP().EjecSP("CRE_ListaSegurosDesmarcados_SP", idSolicitud);
            return DataTableToList.ConvertTo<clsSegurosDesmarcados>(dtRes) as List<clsSegurosDesmarcados>;
        }

        //clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable LisSeguro()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_LisTipoPlanSeguros_SP");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarSeguros(int idCli)
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_ListarSeguros_SP", idCli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerPrecio(int idTipoPlan, int idSolicitud) 
        {
            try
            {
                return new clsGENEjeSP().EjecSP("CRE_ObtenerMontoPlanSeguros_SP", idTipoPlan, idSolicitud);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RPTConsultaSegurosDesmarcados(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return new clsGENEjeSP().EjecSP("CRE_RPTSegurosDesmarcados_SP", dFechaDesde, dFechaHasta);
        }

        public DataTable ADObtenerDatosRPTSeguimientoSeguroOncologico(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("CRE_ObtenerRTPSeguimientoSeguroOncologico_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADValidarPermisosRPTOncologico(int idPerfil)
        {
            return new clsGENEjeSP().EjecSP("CRE_ValidarPermisosRPTOncologico_SP", idPerfil);
        }

        public DataTable ADObtenerPolizaSeguro()
        {
            return new clsGENEjeSP().EjecSP("CRE_ObtenerPolizaSeguro_SP");
        }
    }
}
