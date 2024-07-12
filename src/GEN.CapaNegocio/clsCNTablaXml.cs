using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTablaXml
    {
        clsADTablaXml adtablaxml = new clsADTablaXml(); 
        string cRutaTablasXml = "";
        string cTablaXml = "SI_FINTablasXml";
        
        public void actualizarTablas()
        {
            cRutaTablasXml = clsVarGlobal.cRutPathApp + @"\xml";            

            if (!Directory.Exists(cRutaTablasXml))
            {
               Directory.CreateDirectory(cRutaTablasXml);               
            }
            DirectoryInfo dir = new DirectoryInfo(cRutaTablasXml);
            dir.Attributes = FileAttributes.Normal;

            if (!File.Exists(cRutaTablasXml + @"\" + cTablaXml + ".xml"))
            {
                crearXmlPrincipal(cTablaXml);
            }

            DataTable dtTablaDb = adtablaxml.listarTablasVigente();
            DataTable dtTablaXml = adtablaxml.retonarTablaXml(cTablaXml);

            var lisActualizar= from tDB in dtTablaDb.AsEnumerable()
                               join tXml in dtTablaXml.AsEnumerable() 
                               on (int)tDB["idTabla"] equals (int)tXml["idTabla"]
                               where (int)tDB["nVersion"] != (int)tXml["nVersion"]
                               select tDB ;           

            foreach (DataRow item in lisActualizar)
            {
                crearXml(item["cTabla"].ToString());
            }

            if (lisActualizar.Count()>0)
            {
                crearXml(cTablaXml);
            }
            
            dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }

        private void crearXml(string cTabla)
        {
            DataSet dsTabla = adtablaxml.retonarDatosTabla(cTabla);
            string crutaxml = cRutaTablasXml + @"\" + cTabla + @".xml";
            
            dsTabla.WriteXml(crutaxml, XmlWriteMode.WriteSchema);
        }

        private void crearXmlPrincipal(string cTabla)
        {
            DataSet dsTabla = adtablaxml.retonarDatosTabla(cTabla);

            foreach (DataRow item in dsTabla.Tables[0].Rows)
            {
                item["nVersion"] = 999;
            }
            string crutaxml = cRutaTablasXml + @"\" + cTabla + @".xml";

            dsTabla.WriteXml(crutaxml, XmlWriteMode.WriteSchema);
        }
        
    }
}
