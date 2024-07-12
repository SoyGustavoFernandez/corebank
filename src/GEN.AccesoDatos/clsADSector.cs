using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADSector
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable ADListaSector()
        {
            return ObjEjeSp.EjecSP("GEN_ListaSector_sp");
        }
    }
}
