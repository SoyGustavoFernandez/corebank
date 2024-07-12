using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADTipoGasto
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaTipoGasto()
        {
            return objEjeSp.EjecSP("Gen_ListaGasto_sp");
        }
    }
}
