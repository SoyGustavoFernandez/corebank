using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADEstadoContribuyente
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();

        public DataTable ADListaEstadoContribuyente()
        {
            return ObjEjeSp.EjecSP("GEN_ListaEstadoContribuyente_sp");
        }
    }
}
