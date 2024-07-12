using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADDocIde
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable listarTipoDocs()
        {
            return objEjeSp.EjecSP("GEN_LstParamsxSP_SP", "GEN_LstParamsxSP_SP");
        }
    }
}
