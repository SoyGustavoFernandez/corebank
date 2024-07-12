using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNOperacionCre
    {
        public clsOperacionCre objdocide = new clsOperacionCre();
        public DataTable ListarOperacionCre()
        {
            return objdocide.ListarOperacionCre();
        }

    }
}
