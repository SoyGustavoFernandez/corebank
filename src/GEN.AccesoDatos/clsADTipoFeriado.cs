using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoFeriado
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaTipoFeriado()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoFeriados_sp");
        }
    }
}
