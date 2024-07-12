using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsEstadoCivil
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarEstadoCivil()
        {
            return objEjeSp.EjecSP("Gen_ListaEstadoCivil_sp");
        }
    }
}
