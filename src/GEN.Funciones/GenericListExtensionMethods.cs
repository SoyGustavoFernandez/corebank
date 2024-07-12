using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Data;

namespace GEN.Funciones
{
    public static class GenericListExtensionMethods
    {
        public static string GetXml<T>(this IList<T> GenericList)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmldecl = null;
            XmlSerializer serializer = new XmlSerializer(GenericList.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, GenericList);
                ms.Position = 0;
                xmlDoc.Load(ms);
                xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                return xmlDoc.InnerXml;
            }
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static DataTable ToDataTable<TSource>(this IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
        public static string ListObjectToXml<TSource>(this IEnumerable<TSource> source, string cNombreObjeto = "Objeto", string cNombreLista = "Lista")
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();

            dt = GEN.Funciones.DataTableToList.CreateDataTable<TSource>(source);

            dt.TableName = cNombreObjeto;

            DataSet ds = new DataSet(cNombreLista);
            ds.Tables.Add(dt);

            return ds.GetXml();
        }
        public static string ListObjectToXmlWithColumnFilter<TSource>(this IEnumerable<TSource> source, string cNombreObjeto = "Objeto", string cNombreLista = "Lista", string[] lNombreColumas = null)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();

            dt = GEN.Funciones.DataTableToList.CreateDataTable<TSource>(source);

            dt.TableName = cNombreObjeto;

            lNombreColumas = lNombreColumas ?? new string[0];

            foreach (string columna in lNombreColumas)
            {
                dt.Columns.Remove(columna);
            }

            DataSet ds = new DataSet(cNombreLista);
            ds.Tables.Add(dt);

            return ds.GetXml();
        }
    }
}
