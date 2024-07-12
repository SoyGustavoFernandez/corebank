using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoDireccion
    {
        public clsADDTipoDireccion objTipDireccion = new clsADDTipoDireccion();
        public DataTable ListaTipDireccion()
        {
            return objTipDireccion.ListaTipDireccion();
        }
    }
}
