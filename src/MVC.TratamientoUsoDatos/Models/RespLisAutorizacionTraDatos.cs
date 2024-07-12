using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.TratamientoUsoDatos.Models
{
    public class RespLisAutorizacionTraDatos
    {
        public RespuestaAutTraDatos EstadoRpt;
        public MaestroAutorizacion MaestroAutTratamientoDatos;
        public AutorizaTratamientoUsoDatos[] LisAutorizacion;
    }
}