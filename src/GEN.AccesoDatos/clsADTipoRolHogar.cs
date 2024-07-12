using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
namespace GEN.AccesoDatos
{
    public class clsADTipoRolHogar
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoRolHogar()
        {
            return ObjEjeSp.EjecSP("GEN_ListaTipoRolHogar_sp");
        }
    }
}
