using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace DEP.AccesoDatos
{
    public class clsADDepositosXProd
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarDepXProd(string cidProducto, int idMoneda, int idAgencia, int idEstado, int idTipPersona, int idCaracteristica)
        {
            return objEjeSp.EjecSP("DEP_DepositoXProducto_sp", cidProducto, idMoneda, idAgencia,idEstado, idTipPersona, idCaracteristica);
        }
    }
}
