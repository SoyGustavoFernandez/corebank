using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADClienteCargo
    {
        clsGENEjeSP objEjeSP = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ADListaClienteCargo()
        {
            return objEjeSP.EjecSP("GEN_ListaCliCargo_sp");
        }
        public DataTable ADListaClienteCargoXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinClienteCargo");
        }
        public DataTable ADListaClienteCargoBus(string cCargo)
        {
            return objEjeSP.EjecSP("GEN_ListaCliCargoBus_sp", cCargo);
        }
    }
}
