using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoAporte
    {
        clsGENEjeSP objEjesp = new clsGENEjeSP();
        public DataTable ADListarTipoAporte()
        {
            return objEjesp.EjecSP("DEP_ListaTipoAporte_sp");
        }
    }
}
