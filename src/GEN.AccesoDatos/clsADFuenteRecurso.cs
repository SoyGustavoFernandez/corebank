using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;  

namespace GEN.AccesoDatos
{
    public class clsADFuenteRecurso
    {
        public DataTable ListarFuenteRecurso()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("GEN_ListarRecurso_sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
