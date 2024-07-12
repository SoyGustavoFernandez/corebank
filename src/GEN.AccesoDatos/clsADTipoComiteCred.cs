using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoComiteCred
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoComiteCred()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoComiteCred_Sp");
        }
    }
}
