using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADEstPersonal
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public clsGENEjeSP objEjeSp= new clsGENEjeSP();
        public DataTable ListaEstPersonal()
        {
            return objEjeSp.EjecSP("Gen_ListaEstPersonal_sp");
        }
        public DataTable ListaEstPersonalXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstadoPersonal");
        }
    }
}
