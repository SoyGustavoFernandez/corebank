using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper; 

namespace GEN.AccesoDatos
{
    public class clsADListarHorario
    {
        clsADTablaXml cnadtabla = new clsADTablaXml();
        public DataTable ListarHorario()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarHorarios_SP");
        }        
    }
}
