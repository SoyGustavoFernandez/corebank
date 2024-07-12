using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace GEN.AccesoDatos
{
    public class clsADMeses
    {
        clsADTablaXml adtabla = new clsADTablaXml();
        
        public DataTable listarMesesXML()
        {
            return adtabla.retonarTablaXml("SI_FinMeses");
        }
    }
}
