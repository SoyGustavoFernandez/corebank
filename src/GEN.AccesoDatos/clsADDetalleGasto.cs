using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADDetalleGasto
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarDetalleTipoGasto(int idConcepto)
        {
            return objEjeSp.EjecSP("GEN_ListarDetalleTipoGasto_SP", idConcepto);
        }
    }
}
