using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoVia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaVias()
        {
            return objEjeSp.EjecSP("Gen_ListaTipoVia_sp");
        }
    }
}
