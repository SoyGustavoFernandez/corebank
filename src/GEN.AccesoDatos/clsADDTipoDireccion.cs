using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADDTipoDireccion
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaTipDireccion()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoDir_Sp");
        }
    }
}
