using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsMoneda
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarMoneda()
        {
            return objEjeSp.EjecSP("Gen_ListaMoneda_sp");            
        }
        public DataTable ADListaMonedas()
        {
            return objEjeSp.EjecSP("GEN_ListaMonedas_sp");
        }

        public DataTable ListarMonedaXml()
        {
            return cnadtabla.retonarTablaXml("SI_FINMoneda");
        }
    }
}
