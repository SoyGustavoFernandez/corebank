using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoDocumentoSustento
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarTipoDocumentoSustento()
        {
            return objEjeSp.EjecSP("SPL_ListarTipoDocumentoSustento_SP");
        }

    }
}
