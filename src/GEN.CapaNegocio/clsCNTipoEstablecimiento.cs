﻿using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNTipoEstablecimiento
    {
        clsADTipoEstablecimiento objTipoEstablecimiento = new clsADTipoEstablecimiento();

        public DataTable ListarTipoEstablecimiento()
        {
            return objTipoEstablecimiento.ListarTipoEstablecimiento();
        }
    }
}