using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADModDesembolso
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ConModDes()
        {
            return objEjeSp.EjecSP("CRE_ListaModaDesem_sp");
        }
    }
}
