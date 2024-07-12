using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADReprogramacion
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public clsADReprogramacion()
        {

        }
        public DataSet grabarSolicitudReprogMasivo(string xmlCuentas, int idTipoPlanPago)
        {
            return this.objEjeSp.DSEjecSP("CRE_grabarSolicReprogMasivo_SP", xmlCuentas, idTipoPlanPago);
        }
        public DataSet grabarSolicitudReprogMasivoTEA(string xmlCuentas)
        {
            return this.objEjeSp.DSEjecSP("CRE_GuardarReproMasivaTea_SP", xmlCuentas);
        }
    }
}
