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
    public class clsADAWPreApertura
    {
        #region Variables Privadas
        private IntConexion objEjeSp;
        #endregion

        #region Constructores
        public clsADAWPreApertura()
        {
            this.objEjeSp = new clsGENEjeSP();
        }

        public clsADAWPreApertura(bool lconexion)
        {
            this.objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region Métodos Públicos
        public DataTable buscarBaseNegativa(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("CLI_AWBuscarBaseNegativa_SP", parametros);
        }

        public DataTable buscarPersonaPEP(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("GEN_BuscarPersonaPep_sp", parametros);
        }

        public DataTable buscarCuentasVigentes(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWBuscarCuentasVigentes_SP", parametros);
        }

        public DataTable obtenerPersonaReniec(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("DEP_AWObtenerPersonaReniec_SP", parametros);
        }
        #endregion
    }
}
