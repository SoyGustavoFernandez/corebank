using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipPagoInt
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarTipPagoInt()
        {
            return objEjeSp.EjecSP("Gen_ListaTipPagoInt_sp");
        }
    }
}
