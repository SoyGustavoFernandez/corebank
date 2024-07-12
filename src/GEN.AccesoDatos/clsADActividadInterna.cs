using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADActividadInterna
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable ADListaActividadInterna()
        {
            return ObjEjeSp.EjecSP("GEN_ListaActividadInterna_sp");
        }
    }
}
