using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;   

namespace GEN.AccesoDatos
{
    public class clsADAgencia
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable LisAge() 
        {
            try
            {
                return new clsGENEjeSP().EjecSP("GEN_LisAgencia_sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LisAgeXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinAgencia");
        }
    }
}
