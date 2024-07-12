using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoResidencia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoResidencia()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoResidencia_sp");
        }
    }
}