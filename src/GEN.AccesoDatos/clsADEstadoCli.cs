﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADEstadoCli
    {
        clsGENEjeSP ObjEjesp = new clsGENEjeSP();
        public DataTable ADListaEstadoCli(int idTipoPersona)
        {
            return ObjEjesp.EjecSP("CLI_ListaEstadoCli_sp", idTipoPersona);
        }
    }
}
