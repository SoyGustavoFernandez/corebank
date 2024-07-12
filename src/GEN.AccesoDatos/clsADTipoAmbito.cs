using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoAmbito
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADLisTipoAmbito()
        {
            return objEjeSp.EjecSP("GEN_LisTipoAmbito_SP");
        }
    }
}
