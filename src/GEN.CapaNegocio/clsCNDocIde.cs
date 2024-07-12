using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNDocIde
    {
        public clsADDocIde objdocide = new clsADDocIde();
        public DataTable listarTipoDocs()
        {
            return objdocide.listarTipoDocs();
        }
    }
}
