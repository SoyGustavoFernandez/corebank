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
    public class clsADAWApertura
    {
        #region Variables Privadas
        private IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADAWApertura()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAWApertura(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region Métodos Públicos
        public DataTable obtenerClienteReniec(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CLI_AWObtenerClienteReniec_SP", parametros);
        }

        public DataTable enviarCorreo(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWEnviarCorreoApertura_SP", parametros);
        }

        public DataTable registrarCanal(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWRegistrarCanal_SP", parametros);
        }

        public DataTable registrarTramite(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWRegistrarTramite_SP", parametros);
        }
        #endregion
    }
}
