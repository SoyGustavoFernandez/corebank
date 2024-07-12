using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace DEP.AccesoDatos
{
    public class clsADTipoCuenta
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable LisTipoCuenta()
        {
            return objEjeSp.EjecSP("DEP_LisTipCuentaDep_sp");
        }

        public DataTable LisObjetoAhorro()
        {
            return objEjeSp.EjecSP("DEP_ListaObjetoAhorro_Sp");
        }

        public DataTable LisOrigenFondos()
        {
            return objEjeSp.EjecSP("DEP_ListaOrigenFondos_Sp");
        }

        public DataTable ListaEnvioEstCta()
        {
            return objEjeSp.EjecSP("DEP_ListaTiposEnvioEstadoCta_Sp");
        }
    }
}
