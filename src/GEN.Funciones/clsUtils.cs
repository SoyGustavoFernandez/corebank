using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Text.RegularExpressions;

namespace GEN.Funciones
{
    public class clsUtils
    {
        public static string ConvertToXML(DataTable dtOrigen, string cNodoRoot, string cNodoElement)
        {
            DataTable dt = dtOrigen;
            dt.TableName = cNodoElement;

            DataSet ds = new DataSet(cNodoRoot);
            ds.Tables.Add(dt);

            return EncodingXML(ds.GetXml());
        }

        private static string EncodingXML(string xmlDoc)
        {
            string xmlDirec = "<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>" + xmlDoc;
            xmlDirec = xmlDirec.Replace("\r\n", "").Replace(Environment.NewLine, "");
            return xmlDirec;
        }

        public static decimal MonthDifference(DateTime FechaFin, DateTime FechaInicio)
        {
            return Math.Abs((FechaFin.Month - FechaInicio.Month) + 12 * (FechaFin.Year - FechaInicio.Year));
        }

        public static string ListToXml<T>(List<T> obj)
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            DataTable dtRes = new DataTable(typeof(T).Name);

            foreach (PropertyInfo item in properties)
            {
                Type type = item.GetType();
                dtRes.Columns.Add(item.Name, item.PropertyType);
            }
            

            foreach (var item in obj)
            {
                DataRow dr = CreateRowFromItem<T>(item, properties, dtRes);
                dtRes.Rows.Add(dr);
            }

            DataSet ds = new DataSet("dsDataSet");
            ds.Tables.Add(dtRes);
            return ds.GetXml();
        }

        private static DataRow CreateRowFromItem<T>(T item, IList<PropertyInfo> properties, DataTable dt) 
        {
            DataRow row = dt.NewRow();
            Type type = row.GetType();
            
            foreach (var property in properties)
            {
                row[property.Name] = property.GetValue(item);
            }

            return row;
        }


        public static List<object> ObjectToParams(object obj)
        {
            List<PropertyInfo> properties = obj.GetType().GetProperties().ToList();
            List<dynamic> res = new List<dynamic>();
            foreach (var property in properties)
            {
                res.Add((object)property.GetValue(obj));
            }
            return res;
        }
        
        public static bool EsCorreoValido(string correos)
        {
            // Utiliza una expresión regular para validar cada correo electrónico en la cadena.
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Divido la cadena de correos por saltos de línea y verifico cada correo.
            string[] correosArray = correos.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string correo in correosArray)
            {
                if (!Regex.IsMatch(correo, patronCorreo))
                {
                    return false; // Al menos uno de los correos no es válido.
                }
            }
            return true; // Todos los correos son válidos.
        }

        #region Conversion de Object to XML

        /* lfeijoo
         * Converción de Object to XML 
         * */

        public static String toXmlObject(object obj)
        {          
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());

            //DataSet ds = new DataSet("dsDataSet");
            //ds.Tables.Add(dtRes);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                serializer.Serialize(ms, obj);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return RemoveAllNamespaces(xmlDoc.InnerXml);
            }
            
        }

        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        public static string ConvertirObjetoXml<T>(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            string xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                    xml = sww.ToString();
                }
            }
            return xml;
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
        #endregion

        public int CalcularEdad(DateTime start, DateTime end)
        {
            try
            {
                return (end.Year - start.Year - 1) +
                    (((end.Month > start.Month) ||
                    ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DateTime? TextoToFecha(string cFecha)
        {
            try
            {
                if (!string.IsNullOrEmpty(cFecha))
                {
                    int dia = Convert.ToInt32(cFecha.Substring(6, 2));
                    int mes = Convert.ToInt32(cFecha.Substring(4, 2));
                    int anio = Convert.ToInt32(cFecha.Substring(0, 4));

                    DateTime date1 = new DateTime(anio, mes, dia);
                    return date1;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int GenerarNumeroAleatorio(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        public DateTime GenerarFechaAleatoria()
        {
            Random random = new Random();
            DateTime fechaActual = DateTime.Now;
            return fechaActual.AddDays(-random.Next(1, 30));
        }
    }
}
