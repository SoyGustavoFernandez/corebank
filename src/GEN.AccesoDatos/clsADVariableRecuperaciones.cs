using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADVariableRecuperaciones
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listar()
        {
            return objEjeSp.EjecSP("RCP_ListarVariableRecuperacion_SP");
        }
    }
}
