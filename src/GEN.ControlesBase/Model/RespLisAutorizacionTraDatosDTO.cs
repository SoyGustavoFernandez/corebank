﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEN.ControlesBase.Model
{
    public class RespLisAutorizacionTraDatosDTO
    {
        public RespuestaAutTraDatos EstadoRpt;
        public DocumentoAutorizacion DocumentoAutorizacionRpt;

        public AutorizaTratamientoUsoDatos[] LisAutorizacion;

    }
}