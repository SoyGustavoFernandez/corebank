using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GEN.Funciones
{
    public class DataTableToList
    {
        public static IList<T> ConvertTo<T>(DataTable table) where T : new()
        {
            var dataList = new List<T>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            var objFieldNames = (from PropertyInfo aProp in typeof(T).GetProperties(flags)
                                 select new
                                 {
                                     Name = aProp.Name,
                                     Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                                 }).ToList();

            var dataTblFieldNames = (from DataColumn aHeader in table.Columns
                                     select new
                                     {
                                         Name = aHeader.ColumnName,
                                         Type = aHeader.DataType
                                     }).ToList();

            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in table.AsEnumerable().ToList())
            {
                var clsObj = new T();

                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = clsObj.GetType().GetProperty(aField.Name);
                    var value = (dataRow[aField.Name] == DBNull.Value) ? null : dataRow[aField.Name];   //if database field is nullable

                    propertyInfos.SetValue(clsObj, value, null);
                }

                dataList.Add(clsObj);
            }

            return dataList;
        }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            bool lIgnore = false;
            bool[] lIgnores = new bool[properties.Length];
            int j = 0;

            foreach (PropertyInfo info in properties)
            {
                lIgnore = !info.GetCustomAttributes(false).Any(x => x is XmlIgnoreAttribute);
                lIgnores[j++] = lIgnore;
                if(lIgnore)
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[dataTable.Columns.Count];
                for (int i = 0, k = 0; i < properties.Length; i++)
                {
                    if(lIgnores[i])
                        values[k++] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        /// <summary>
        /// Convierte un objeto DataTable en un objeto genérico especificado, asignando los valores de las filas y columnas correspondientes.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto genérico al que se va a convertir el DataTable.</typeparam>
        /// <param name="dataTable">DataTable que se va a convertir en el objeto.</param>
        /// <returns>Un objeto genérico con los valores asignados desde el DataTable.</returns>
        public static T ConvertToObject<T>(DataTable dataTable) where T : new()
        {
            T obj = new T();
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    string propertyName = col.ColumnName;
                    object value = row[col];

                    PropertyInfo property = obj.GetType().GetProperty(propertyName);
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(obj, value, null);
                    }
                }
            }

            return obj;
        }
    }
}
