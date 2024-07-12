using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.TratamientoUsoDatos.Models
{
    public class Auditoria
    {
        public int idUsuRegistro { get; set; }
        public DateTime dFecRegistro { get; set; }
        public int idUsuModifica { get; set; }
        public DateTime dFecModifica { get; set; }

        public static byte[] String2ByteArray(string str)
        {
            char[] chars = str.ToArray();
            byte[] bytes = new byte[chars.Length * 2];

            for (int i = 0; i < chars.Length; i++)
                Array.Copy(BitConverter.GetBytes(chars[i]), 0, bytes, i * 2, 2);

            return Convert.FromBase64String(str); //bytes;
        }

        public static string ByteArray2String(byte[] bytes)
        { 
            return Convert.ToBase64String(bytes);  
        }
    }
}