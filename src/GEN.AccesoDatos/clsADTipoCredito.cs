using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoCredito
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarTipoCredito()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoCredito_SP");
        }
    }
}
