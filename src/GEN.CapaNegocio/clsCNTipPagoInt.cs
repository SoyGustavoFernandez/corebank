﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipPagoInt
    {
        public clsADTipPagoInt Lista = new clsADTipPagoInt();
        public DataTable ListarTipPagoInt() {
            return Lista.ListarTipPagoInt();
        
        }
    }
}
