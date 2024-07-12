using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace ADM.AccesoDatos
{
    public class clsADConfiguracionImpresionContratos
    {
       IntConexion objEjeSp;

        public clsADConfiguracionImpresionContratos(bool lConexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public clsADConfiguracionImpresionContratos()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable listarConfiguracion()
        {
            return objEjeSp.EjecSP("ADM_ListarConfiguracionImpresionContratos_SP");
        }

        public DataTable actualizarVariableConfiguracion(int idVariable, string cValor)
        {
            return objEjeSp.EjecSP("ADM_ActualizarConfiguracionImpresionContratos_SP", idVariable, cValor);
        }

        public DataTable obtenerVariableConfiguracion()
        {
            return objEjeSp.EjecSP("ADM_ObtenerVariableImpresionContratos_SP");
        }

        public DataTable listarIntervinientes(int idModulo, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarIntervinientes_SP", idModulo, idSolicitud);
        }

        public DataTable listarIntervinientesImprimir(int idModulo, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RptListaIntervinientesFirma_SP", idModulo, idSolicitud);
        }

        public DataTable guardarRegistroImpresion(int nModulo, int idSolicitud, int idPerfil, int idUsuario, string cCadenaEncriptada)
        {
            return objEjeSp.EjecSP("CRE_RegistrarLogImpresionContrato_SP", nModulo, idSolicitud, idPerfil, idUsuario, cCadenaEncriptada);
        }

        public DataTable obtenerNumeroImpresiones(int nModulo, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObteberNumeroDeImpresionesContrato_SP", nModulo, idSolicitud);
        }

        public DataTable obtenerDocumentoPlantilla(string cNombre)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDocumentoPlantilla_SP", cNombre);
        }

        public DataTable obtenerFechaCuenta(int idModulo, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerFechaRegistroCuenta_SP", idModulo, idSolicitud);
        }
    }
}