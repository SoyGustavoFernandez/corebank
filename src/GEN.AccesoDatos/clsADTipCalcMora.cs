using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipCalcMora
    {
        public DataTable ADGetTipCalcMora()
        {
            return new clsGENEjeSP().EjecSP("CRE_LisFuenteCalcMora_Sp");
        }
    }
}
