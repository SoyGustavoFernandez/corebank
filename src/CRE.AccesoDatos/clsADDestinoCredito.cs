using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using GEN.AccesoDatos;

namespace CRE.AccesoDatos
{
    public class clsADDestinoCredito
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListaDestinoCredito(int idProducto = 0)
        {
            return objEjeSp.EjecSP("CRE_ListaDestinoCredito_sp", idProducto);
        }

        
        public DataTable ListaDestinoCreditoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinDestinoCredito");
        }
        
    }
}
