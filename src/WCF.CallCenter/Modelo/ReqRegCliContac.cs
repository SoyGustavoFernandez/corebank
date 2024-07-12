using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.CallCenter.Modelo
{
    public class ReqRegCliContac
    {
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        public int cNroContacto { get; set; }
        public int idMotivo { get; set; }
        public string cMotivoOtros { get; set; }
        public string dFechaPago { get; set; }
        public decimal nMonto { get; set; }
        public int idTipoContacto { get; set; }
        public string cObservaciones { get; set; }
        public int idRespuesta { get; set; }
        public string cUsuario { get; set; }
    }
}