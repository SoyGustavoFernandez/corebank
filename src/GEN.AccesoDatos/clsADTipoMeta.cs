using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoMeta
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoMeta(int idTipoIncentivo)
        {
            return objEjeSp.EjecSP("GEN_TipoMeta_sp", idTipoIncentivo);
        }
    }
}
