using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLI.AccesoDatos;
using System.Data;

namespace CLI.CapaNegocio
{
    public class clsCNListarRelacionLaboral
    {
        clsADListarRelacionLaboral objListaActEco = new clsADListarRelacionLaboral();
        public DataTable ListarRelLaboral()
        {
            return objListaActEco.ListarRelLaboral();
        }
    }
}
