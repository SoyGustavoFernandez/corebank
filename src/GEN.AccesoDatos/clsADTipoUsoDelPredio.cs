using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoUsoDelPredio
    {

        public DataTable ListaTipoUsoDelPredio()
        {
            return new clsGENEjeSP().EjecSP("gen_ListaTipoUsoDelPredio_sp");
        }

    }//end class

}
