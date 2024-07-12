using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GEN.Funciones
{
    public static class DataTableExtensions
    {
        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    if (row[property.Name] != System.DBNull.Value)
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                }
            }
            return item;
        }


        public static IList<T> SoftToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = SoftCreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static T ToObject<T>(this DataRow dr) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            T result = new T();

            result = SoftCreateItemFromRow<T>(dr, properties);                
           
            return result;
        }

        private static T SoftCreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    try
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                    catch (Exception e)
                    {
                        property.SetValue(item, null);
                    }
                }
            }
            return item;
        }
    }
}
