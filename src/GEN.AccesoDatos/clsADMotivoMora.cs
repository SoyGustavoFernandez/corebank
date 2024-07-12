using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADMotivoMora
    {
        clsGENEjeSP clsGENEjeSP = new clsGENEjeSP();
        public DataTable Lista()
        {
            return clsGENEjeSP.EjecSP("GEN_ListarMotivoMora_SP");
        }
    }
}
