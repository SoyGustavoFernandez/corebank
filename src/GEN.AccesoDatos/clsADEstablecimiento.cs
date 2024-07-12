using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADEstablecimiento
    {
        clsGENEjeSP ObjEjeSP = new clsGENEjeSP();
        public DataTable ADListar()
        {
            return ObjEjeSP.EjecSP("GEN_ListarEstablecimientosGiros_SP");
        }
    }
}
