using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper; 
namespace GEN.AccesoDatos
{
    public class clsADListaDiasSemana
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public DataTable ListarDiasSemana()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarDiasSemana_SP");
        }
        public DataTable ListarDiasSemanaXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinDiaSemana");
        }

    }
}
