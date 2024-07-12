using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsCriBusCli

    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        // Crer Metodo para Ejecutar SP de Listado de Creterio de Busqueda
        public DataTable listarCriBusCli()
        {
            return objEjeSp.EjecSP("Gen_ListaCriBusCli_sp");
        }
        public DataTable listarCriBusCliXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinCriBusCli");
        }
    }
}
