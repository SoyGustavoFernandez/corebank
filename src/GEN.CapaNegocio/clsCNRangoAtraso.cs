﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNRangoAtraso
    {
        public DataTable CNRangoAtraso()
        {
            return new clsADRangoAtraso().ADRangoAtraso();
        }
    }
}
