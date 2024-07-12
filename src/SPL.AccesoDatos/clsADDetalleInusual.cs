using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADDetalleInusual
    {
        public DataTable ListarDetalleInusual(int codDetalle)
        {
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("GEN_ListarDetalleInusualSPL", codDetalle);
            return ds;
        }
    }
}
