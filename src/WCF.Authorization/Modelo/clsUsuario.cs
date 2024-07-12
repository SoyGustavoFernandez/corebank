using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Authorization.Modelo
{
    public class clsUsuario
    {
        public int idPDPUsuarioAuth { get; set; }
        public int idApiEmpresa { get; set; }
        public string cUsuario { get; set; }
        public string cPassword { get; set; }
        public string cSalt { get; set; }
        public DateTime dFecReg { get; set; }
        public bool lVigente { get; set; }
    }
}