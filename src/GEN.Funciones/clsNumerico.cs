using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.Funciones
{
    public class clsNumerico
    {
        /*public static decimal ParseDecimal(String stringValue)
        {
            bool esDecimal = true;
            decimal decimalValue = 0;

            esDecimal = decimal.TryParse(stringValue, out decimalValue);

            return decimalValue;
        }

        public static int ParseInt(String stringValue)
        {
            bool esInt = true;
            int intValue = 0;

            esInt = int.TryParse(stringValue, out intValue);

            return intValue;
        }

        public static string cadenaDecimal(string stringValue)
        {
            bool esDecimal = true;
            decimal decimalValue = 0;

            esDecimal = decimal.TryParse(stringValue, out decimalValue);

            return Convert.ToString(decimalValue);
        }

        public static string cadenaEntero(string stringValue)
        {
            bool esInt = true;
            int intValue = 0;

            esInt = int.TryParse(stringValue, out intValue);

            return Convert.ToString(intValue);
        }
*/
        public static decimal StringToDecimal(string stringValue)
        {
            bool esDecimal = true;
            decimal decimalValue = 0;

            esDecimal = decimal.TryParse(stringValue, out decimalValue);

            return decimalValue;
        }

        public static int StringToInt(string stringValue)
        {
            bool esInt = true;
            int intValue = 0;

            esInt = int.TryParse(stringValue, out intValue);

            return intValue;
        }

        public static decimal Dividir(decimal dividendo, decimal divisor)
        {
            if (divisor == 0) return 0;

            return dividendo / divisor;
        }
    }
}
