using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNMontos
    {
        public clsADMontos objdocide = new clsADMontos();
        public DataTable ListarMontos(int idModulo)
        {
            return objdocide.ListarMontos(idModulo);
        }

        public DataTable ListarMontosTodos(int idModulo)
        {
            return objdocide.ListarMontosTodos(idModulo);
        }
    }
}
