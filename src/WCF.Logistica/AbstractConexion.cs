using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Logistica
{
    public class AbstractConexion
    {
        public string getToken()
        {
            return HttpContext.Current.Request.Headers["Authorization"].ToString();
        }
    }
}