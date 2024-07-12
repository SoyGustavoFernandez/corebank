using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEN.CapaNegocio
{
    public static class clsCNFormatoXML
    {
        public static string EncodingXML(string xmlDoc)
        {
            string xmlDirec = "<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>" + xmlDoc;
            xmlDirec = xmlDirec.Replace("\r\n", "").Replace(Environment.NewLine, "");
            return xmlDirec;
        }
    }
}
