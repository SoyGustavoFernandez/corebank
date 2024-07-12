using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper; 

namespace GEN.AccesoDatos
{
    public class clsADTipoValor
    {
        public DataTable ListaTipoValor()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("GEN_ListarTipoValor_sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
