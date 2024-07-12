using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEP.AccesoDatos.AhorroWeb
{
    public class clsADAWGeneral
    {
        #region Variables Privadas
        private IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADAWGeneral()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAWGeneral(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region Métodos Públicos
        public DataTable obtenerProductos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWObtenerProductos_SP", parametros);
        }

        public DataTable obtenerMonedas()
        {
            return this.objEjeSp.EjecSP("Gen_ListaMoneda_sp");
        }

        public DataTable obtenerProfesiones()
        {
            return this.objEjeSp.EjecSP("Gen_ListaProfesion_Sp");
        }

        public DataTable obtenerActividadesInternas()
        {
            return this.objEjeSp.EjecSP("GEN_AWObtenerActividadesInternas_SP");
        }

        public DataTable obtenerLog(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWObtenerLog_SP", parametros);
        }

        public DataTable registrarLog(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWRegistrarLog_SP", parametros);
        }

        public DataTable buscarCliente(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CLI_AWBuscarCliente_SP", parametros);
        }

        public DataTable obtenerDireccionReniec(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CLI_AWObtenerDireccionReniec_SP", parametros);
        }

        public DataTable buscarPersonaReniec(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("GEN_ConsultaDatosRen_SP", parametros);
        }

        public DataTable obtenerVariable(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("ADM_ObtenerVariable_SP", parametros);
        }

        public DataTable obtenerAgencias(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("GEN_ListAgenciasUsu_Sp", parametros);
        }

        public DataTable obtenerPerfiles(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("GEN_LisPerUsu_sp", parametros);
        }

        public DataTable obtenerDocumentoAutorizado(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CLI_RecuperaDatosDocAutorizado_SP", parametros);
        }

        public DataTable obtenerRestriccionPersona(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CLI_AWObtenerRestriccionPersona_SP", parametros);
        }

        public DataTable obtenerParametrosTramite(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWObtenerParametrosTramite_SP", parametros);
        }
        
        public DataTable ObtenerObjetosAhorro(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_ListaObjetoAhorro_Sp", parametros);
        }

        #endregion
    }
}
