using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsFeriado
    {
        public DateTime dFeriado { get; set; }
        public int idTipoFeriado { get; set; }
        public bool lVigente { get; set; }
        public char cEstado { get; set; }
        public int idAgencia { get; set; }
        public string cNomCorto { get; set; }
        public string cDescFeriado { get; set; }
        public string cNombreAge { get; set; }
    }
}
