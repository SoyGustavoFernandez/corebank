using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoVivienda
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaViviendas()
        {
            return objEjeSp.EjecSP("gen_ListaTipoVivienda_sp");
        }
    }
}
