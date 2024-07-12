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
    public class clsADViaticos
    {
        #region propiedades privadas
        private IntConexion objEjeSp;
        #endregion

        #region constructores
        public clsADViaticos()
        {
            this.objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region métodos públicos
        public DataTable registrarViatico(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarEntregaViatico_SP", parametros);
        }

        public DataTable obtenerViatico(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerViaticoEntrega_SP", parametros);
        }

        public DataTable obtenerDetallesViatico(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerDetalleViatico_SP", parametros);
        }
        #endregion
    }
}
