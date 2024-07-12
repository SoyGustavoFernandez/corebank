using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsRetornaCuentaSolCliente
    {
        IntConexion objEjeSp;

        public clsRetornaCuentaSolCliente()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsRetornaCuentaSolCliente(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable RetornaCuentaSolCliente(int nIdCliente, string cTipoBusqueda, string cEstado)
        {
            return objEjeSp.EjecSP("Cre_RetornaCuentaSolCliente_sp", nIdCliente, cTipoBusqueda, cEstado);
        }

        public DataTable ADRetDetCuentasVinculadas(int idCliente, int idOperacion)
        {
            return objEjeSp.EjecSP("CRE_RetDetCuentasVinculadas_SP", idCliente, idOperacion);
        }

        public DataTable ADRetDetCuentasVinculadasxSoli(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetDetCuentasVincPorSolicud_SP", idSolicitud);
        }
        public DataTable RetornaCuentaXSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtieneCuentaXSolicitud_SP", idSolicitud);
        }
        public DataTable ADRetornaPoliticaPrivacidadCliente(int idCli)
        {
            return objEjeSp.EjecSP("GEN_ObtenerMenuExpedientePolitPriv_SP", idCli, "politicaPrivacidad");
        }
        public DataTable ADRecuperaPdfSentinel(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RecuperaArchivoSentinelPDF", idSolicitud);
        }
        public DataTable ADRecuperaPdfsolTasa(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RecuperaArchivoSOLTasaNegociablePDF_SP", idSolicitud);
        }
        public DataTable ADRecuperaPdfTasaNegociable(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RecuperaArchivoTasaNegociablePDF_SP", idSolicitud);
        }
        public DataTable ADObtenerSubProducto(int idSubProducto)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSubProducto_SP", idSubProducto);
        }
    }
}
