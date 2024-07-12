using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Authorization.Modelo
{
    public class ResAuth
    {
        public string cCodigo { get; set; }
        public string cMensaje { get; set; }
        public string cExpiresIn { get; set; }
        public string cToken { get; set; }
        public string cRefreshToken { get; set; }
    }
}