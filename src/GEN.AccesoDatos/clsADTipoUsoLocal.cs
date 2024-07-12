using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoUsoLocal
    {
        public DataTable ListarTipoUsoLocal()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("Gen_ListarTipoUsoLocal_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
