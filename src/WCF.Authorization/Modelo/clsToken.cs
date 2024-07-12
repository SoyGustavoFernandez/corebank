using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Authorization.Modelo
{
    public class clsToken
    {
        public int idPDPTokenAuth { get; set; }
        public int idPDPUsuarioAuth { get; set; }
        public int idApiEmpresa { get; set; }
        public string cToken { get; set; }
        public DateTime dFecCrea { get; set; }
    }
}