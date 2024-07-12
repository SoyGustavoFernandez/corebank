using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADZonaRegistral
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListarZonaRegistral(Int32 nIdZonaReg)
        {
            return objEjeSp.EjecSP("Gen_ListaZonaRegistral_sp", nIdZonaReg);
        }
    }
}
