using System;
using System.Text;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace WCF.Corebank.Utilities
{
    public class Str
    {

        /* 
         * lfeijoo
         * @function
         * Extrae las primeras palabras de una cadena segun n
         */
        public string extraerNPalabras(string cadena, int palabras)
        {
            if (String.IsNullOrWhiteSpace(cadena)) throw new ArgumentNullException();
            cadena = cadena.Trim();
            char[] separadores = { ' ', '.', ',', '(', ')' };
            string[] tokens = cadena.Split(separadores);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < palabras; ++i)
            {
                sb.Append(tokens[i]);
                sb.Append(' ');
            }
            sb.Length -= 1;
            return sb.ToString();
        }
    }
}