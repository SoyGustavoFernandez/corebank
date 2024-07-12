using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper; 

namespace GEN.AccesoDatos
{
    public class clsADListarTipContrPers
    {
        public DataTable ListarTipContrPers()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTipContrPers_SP");
        }
    }
}
