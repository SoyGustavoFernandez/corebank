using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.Rendiciones.AccesoDatos
{
    public class clsADRendicionesVencidas
    {
                #region propiedades privadas
        private IntConexion objEjeSp;
        #endregion

        #region constructores
        public clsADRendicionesVencidas()
        {
            this.objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region métodos públicos
        public DataTable obtenerRendicionesVencidas(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerRendicionesVencidas_SP", parametros);
        }
        #endregion
    }
}
