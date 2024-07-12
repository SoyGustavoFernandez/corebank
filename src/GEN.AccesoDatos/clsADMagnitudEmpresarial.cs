using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADMagnitudEmpresarial
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable ADListaMagnitudEmpresarial(int idTipoPersona = 0)
        {
            return ObjEjeSp.EjecSP("GEN_ListaMagnitudEmpresarial_sp", idTipoPersona);
        }
    }
}
