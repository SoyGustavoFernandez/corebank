using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;


namespace GEN.CapaNegocio
{
    public class clsCNTipoValor
    {
        public DataTable ListaTipoValor()
        {
            return new clsADTipoValor().ListaTipoValor();
        }
    }
}
