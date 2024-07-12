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
    public class clsADAWCliente
    {
        #region Variables Privadas
        private IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADAWCliente()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAWCliente(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region Métodos Públicos
        public DataTable guardarCliente(params object[] parametros)
        {
            return objEjeSp.EjecSP("Gen_GuardarCliPerNat_Sp", parametros);            
        }

        public DataTable actualizarCliente(params object[] parametros)
        {
            return objEjeSp.EjecSP("CLI_AWPreActualizarCliente_SP", parametros);
        }
        #endregion
    }
}
