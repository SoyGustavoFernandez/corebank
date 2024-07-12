using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Authorization.Modelo
{
    public class ResObtenerEstServ
    {
        public EstadoRespuesta EstRpt { set; get; }
        public string cEmpresa { set; get; }
        public string cUsuario { set; get; }
        public string dFechaReg { set; get; }
        public string dFechaAct { set; get; }
        public bool lEstado { set; get; }
    }
}