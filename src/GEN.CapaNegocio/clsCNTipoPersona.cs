using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoPersona
    {
        public clsADTipPersona objdocide = new clsADTipPersona();
        
        public DataTable listarTipoPersona()
        {
            return objdocide.ADListarTipoPersona();
        }

        public DataTable CNListarTipPersonaProducto(int idProducto)
        {
            return objdocide.ADListarTipPersonaProducto(idProducto);
        }
    }   
}
