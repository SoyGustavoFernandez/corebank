using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SPL.AccesoDatos;

namespace SPL.CapaNegocio
{
    public class clsCNListaTipoFondos
    {
        public DataTable ListaTipoFondos(Boolean lTipo)
        {

            clsADListaTipoFondos listaTipoFondos = new clsADListaTipoFondos();
            return listaTipoFondos.ListaTipoFondos(lTipo);

        }
    }
}
