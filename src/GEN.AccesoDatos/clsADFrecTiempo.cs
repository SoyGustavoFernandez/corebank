using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GEN.AccesoDatos
{
    public class clsADFrecTiempo
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public DataTable ListarFrecTiempo()
        {
            try
            {
                return new clsGENEjeSP().EjecSP("Gen_ListarFrecTiempo_Sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarFrecTiempoXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinTipoPeriodo");
        }
    }
}
