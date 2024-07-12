using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SPL.AccesoDatos
{
    public class clsADListaTipoFondos
    {
        public DataTable ListaTipoFondos(Boolean lTipo)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("SPL_ListaTipoFondos_SP", lTipo);
            return ds;
        }
    }
}
