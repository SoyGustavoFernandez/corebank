using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace CNE.AccesoDatos
{
    public class clsADConciliacionPagos
    {
        private clsGENEjeSP objEjeSp;

        public clsADConciliacionPagos()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ObtenerConfiguracionCanalesElectronicos(int idCanal = 0)
        {
            return this.objEjeSp.EjecSP("CNE_ObtenerConfigCanalElect_SP", idCanal);
        }

        public DataTable ObtenerPagosKardex(int idCanal, DateTime dFechaConci, DateTime dFechaConciFinal)
        {
            return this.objEjeSp.EjecSP("CNE_ObtenerPagosKardex_SP", idCanal, dFechaConci, dFechaConciFinal);
        }
    }
}