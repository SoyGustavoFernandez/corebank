using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADTipoTel
    {

        public DataTable ListarTipoTel()
        {
            return new clsGENEjeSP().EjecSP("Gen_ListarTipotel_sp");
        }

      
    }
}
