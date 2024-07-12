using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoValorado
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoValorados()
        {
            return objEjeSp.EjecSP("GEN_ListaTipoValorado_sp");
        }
    }
}
