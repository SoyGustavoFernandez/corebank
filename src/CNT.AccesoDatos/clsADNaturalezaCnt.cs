using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.AccesoDatos
{
   public class clsADNaturalezaCnt
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaNaturalezaCta()
        {
            return objEjeSp.EjecSP("CNT_ListaTipoNaturalezaCta_SP");
        }
    }
}
