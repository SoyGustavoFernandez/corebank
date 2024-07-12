using EntityLayer;
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
    public class clsADAWPostApertura
    {
        #region Variables Privadas
        private IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADAWPostApertura()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAWPostApertura(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region Métodos Públicos
        public DataTable obtenerDireccionPrincipal(params object[] parametros)
        {
            return objEjeSp.EjecSP("CLI_AWObtenerDirPrincipal_SP", parametros);
        }

        public DataTable actualizarCliente(params object[] parametros)
        {
            return objEjeSp.EjecSP("CLI_AWPostActualizarCliente_SP", parametros);
        }

        public DataTable validarCuentaAperturada(params object[] parametros)
        {
            return objEjeSp.EjecSP("DEP_AWValidarCuentaAperturada_SP", parametros);
        }

        public DataTable registrarRegularizacion(params object[] parametros)
        {
            return objEjeSp.EjecSP("DEP_AWRegistrarRegularizacion_SP", parametros);
        }
        #endregion
    }
}
