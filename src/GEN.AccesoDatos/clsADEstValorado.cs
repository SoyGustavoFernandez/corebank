using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADEstValorado
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADEstValorados()
        {
            return objEjeSp.EjecSP("GEN_ListaEstValorado_sp");
        }
        public DataTable ADEstValoradosOP()
        {
            return objEjeSp.EjecSP("DEP_ListaEstadoValorado_SP");
        }
    }
}
