using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoEstablecimiento
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoEstablecimiento()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoEstablecimiento_sp");
        }
    }
}
