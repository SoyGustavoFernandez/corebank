using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoAsiento
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarTipoAsiento(int idModulo)
        {
            return objEjeSp.EjecSP("Gen_ListaTipoAsiento_sp", idModulo);
        }
    }
}
