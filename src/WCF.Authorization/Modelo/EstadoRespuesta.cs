using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Authorization.Modelo
{
    public class EstadoRespuesta
    {
        public bool lResultado { set; get; }
        public string cEstCode { set; get; }
        public string cMensaje { set; get; }
    }
}