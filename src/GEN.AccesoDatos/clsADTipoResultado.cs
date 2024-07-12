using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoResultado
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable Lista()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoResultado_sp");
        }
    }
}
