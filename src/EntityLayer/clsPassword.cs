using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public static class clsPassword
    {
        public static string cUsuDB { get; set; }
        public static string cPassUsuDB { get; set; }
        public static string cRole { get; set; }
        public static string cPassRole { get; set; }
        public static string cUsuSA{ get; set; }
        public static string cPassSA { get; set; }
        public static bool lCambioClave { get; set; }
        public static string cUltimaClave { get; set; }        

        public static string parsearClave(string cClave)
        {
            cClave = "'" + cClave.Replace("'", "''") + "'";
            return cClave;
        }
    }
}
