using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNPlazos
    {
        public clsADPlazos objdocide = new clsADPlazos();
        public DataTable ListarPlazos(int idModulo)
        {
            return objdocide.ListarPlazos(idModulo);
        }

        public DataTable ListarPlazosTodos(int idModulo)
        {
            return objdocide.ListarPlazosTodos(idModulo);
        }


    }
}
