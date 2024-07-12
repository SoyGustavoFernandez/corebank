using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoEstructuraPredominante
    {
        clsADTipoEstructuraPredominante objlistaEstructuraPredominante = new clsADTipoEstructuraPredominante();

        public DataTable ListaEstructuraPredominante()
        {
            return objlistaEstructuraPredominante.ListaTipoEstructuraPredominante();
        }

    }//end class

}
