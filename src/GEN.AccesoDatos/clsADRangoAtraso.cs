using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADRangoAtraso
    {
        public DataTable ADRangoAtraso()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("GEN_ConsultaRangoAtraso_sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
