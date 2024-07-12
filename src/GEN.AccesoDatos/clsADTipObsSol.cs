using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipObsSol
    {
        public clsGENEjeSP objEjesp = new clsGENEjeSP();

        public DataTable ADLstTipObsSol()
        {
            return objEjesp.EjecSP("CRE_LstTipObsSol_Sp");
        }
    }
}
