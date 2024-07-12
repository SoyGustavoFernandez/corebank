using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADInusualSplaft
    {
        public DataTable ListarInusual()
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("GEN_ListarInusualSPL");
            return ds;
        }
    }
}
