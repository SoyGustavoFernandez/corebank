using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADFeriado
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADdtFeriado()
        {
            return objEjeSp.EjecSP("GEN_ListaFeriados_SP");
        }
    }
}
