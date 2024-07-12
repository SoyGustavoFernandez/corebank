using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CLI.AccesoDatos
{
    public class clsADListarRelacionLaboral
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarRelLaboral()
        {
            return objEjeSp.EjecSP("CLI_ListaRelLabInst_Sp");
        }
    }
}
