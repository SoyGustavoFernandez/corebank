﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEN.ControlesBase.Model
{
    public class RespLisAutorizacionTraDatos
    {
        public RespuestaAutTraDatos EstadoRpt;
        public MaestroAutorizacion MaestroAutTratamientoDatos;
        public AutorizaTratamientoUsoDatos[] LisAutorizacion;
    }
}