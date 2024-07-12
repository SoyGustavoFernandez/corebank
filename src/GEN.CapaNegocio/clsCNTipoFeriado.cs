using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoFeriado
    {
        public clsADTipoFeriado objTipFeriado = new clsADTipoFeriado();
        public DataTable ListaTipoFeriado()
        {
            return objTipFeriado.ListaTipoFeriado();
        }
    }
}
