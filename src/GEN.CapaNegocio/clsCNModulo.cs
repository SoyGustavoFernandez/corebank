using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNModulo
    {
        public DataTable LisModulo()
        {
            return new clsADModulo().LisModulo();
        }
    }
}
