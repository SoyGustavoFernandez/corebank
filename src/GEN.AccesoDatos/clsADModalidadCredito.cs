using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADModalidadCredito
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ADListarModalidadCreditoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinModalidadCredito");
        }
    }
}