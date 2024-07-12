using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoCal
    {
        public clsADTipoCalcul objdocide = new clsADTipoCalcul();

        public DataTable listarTipCal()
        {
            return objdocide.listarTipCal();
        }
    }
     
}
