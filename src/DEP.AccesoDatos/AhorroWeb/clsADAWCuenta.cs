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
    public class clsADAWCuenta
    {
        #region Variables Privadas
        private IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADAWCuenta()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAWCuenta(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region Métodos Públicos
        public DataTable obtenerParametroProducto(params object[] parametros)
        {
            return objEjeSp.EjecSP("DEP_RetornaParamProd_Sp", parametros);
        }
        
        public DataTable obtenerTasa(params object[] parametros)
        {
            return objEjeSp.EjecSP("DEP_ExtraeTasaAhorro_sp", parametros);
        }
        #endregion
    }
}
