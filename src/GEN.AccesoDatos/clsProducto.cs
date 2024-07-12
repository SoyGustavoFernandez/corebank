using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsProducto
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarProducto(Int32 cCodPro)
        {
            return objEjeSp.EjecSP("CRE_ListaProducto_SP", cCodPro);
        }
    }
}
