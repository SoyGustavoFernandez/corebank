using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoIdentificacionPerJur
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipoidentificacion()
        {
            return objEjeSp.EjecSP("Gen_ListarTipoIdentificacionPerJur_sp");
        }
    }
}
