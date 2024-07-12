using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADRecuperaZonaAgencia
    {
        clsGENEjeSP ObjEjeSP = new clsGENEjeSP();
        public DataTable ADRecuperaZonaAgencia(int idAge)
        {
            return ObjEjeSP.EjecSP("GEN_RetornaZonaAgencia_SP", idAge);
        }
    }
}