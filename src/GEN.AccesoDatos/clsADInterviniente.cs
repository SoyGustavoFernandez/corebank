using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADInterviniente
    {
        public clsGENEjeSP ADTipoInterv = new clsGENEjeSP();
        public DataTable listarTipoIntervRegCredito()
        {
            return ADTipoInterv.EjecSP("CRE_LstTipoIntervRegCredito_SP");
        }

        public DataTable ADListaTipoInterv()
        {
            return ADTipoInterv.EjecSP("CRE_LisTipoInterv_SP");
        }

        public DataTable ADListaTipoIntervDep()
        {
            return ADTipoInterv.EjecSP("DEP_LisTipoInterv_SP");
        }

        public DataTable ListarIntervinientesCredito(int idCuenta)
        {
            return ADTipoInterv.EjecSP("GEN_ListarIntervinientesXCredito_sp", idCuenta);
        }
    }
}
