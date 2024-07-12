using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADOperacionCre
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarOperacionCre()
        {
            return objEjeSp.EjecSP("CRE_OperacionSolicita_sp");
        }

    }
}
