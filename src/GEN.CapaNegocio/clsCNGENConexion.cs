using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.CapaNegocio
{
    public class clsCNGENConexion
    {
        public static ArrayList leeXML()
        {
            try
            {
                return clsGENConexion.leeXML();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
