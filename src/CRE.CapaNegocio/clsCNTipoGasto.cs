using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNTipoGasto
    {
        clsADTipoGasto objTipoGasto = new clsADTipoGasto();
        public DataTable ListaTipoGasto()
        {
            return objTipoGasto.ListaTipoGasto();
        }
    }
}
