using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoAccionesEmp
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarTipoAcciones()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTipoAccionesEmp_SP");
        }
        public DataTable ListarTipoAccion()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTipoAccionEmp_sp");
        }
    }
}
