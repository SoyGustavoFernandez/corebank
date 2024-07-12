using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
   
    public class clsCNTipoAsiento
    {
        public clsADTipoAsiento objdocide = new clsADTipoAsiento();
        public DataTable ListarTipoAsiento(int idModulo)
        {
            return objdocide.ListarTipoAsiento(idModulo);
        }
    }
}
