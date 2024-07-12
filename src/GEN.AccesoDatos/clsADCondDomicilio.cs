using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADCondDomicilio
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaCondDomicilio()
        {
            return objEjeSp.EjecSP("GEN_ListaCondDomicilio_sp");
        }
    }
}
