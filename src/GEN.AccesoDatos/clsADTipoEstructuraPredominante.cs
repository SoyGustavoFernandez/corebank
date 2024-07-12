using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoEstructuraPredominante
    {

        public DataTable ListaTipoEstructuraPredominante()
        {
            return new clsGENEjeSP().EjecSP("gen_ListaTipoEstructuraPredominante_sp");
        }

    }//end class

}
