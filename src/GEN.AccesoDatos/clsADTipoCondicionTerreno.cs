using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoCondicionTerreno
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoCondicionTerreno()
        {
            return objEjeSp.EjecSP("GEN_TipoCondicionTerreno_sp");
        }
    }
}
