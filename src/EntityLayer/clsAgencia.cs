using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsAgencia
    {
        public int idAgencia { get; set; }
        public string cNombreAge { get; set; }
        public string cZona { get; set; }
        public string cNomCorto { get; set; }
        public int idUbigeo { get; set; }
        public string cDirección { get; set; }
        public string cRefDirec { get; set; }
        public string cFono { get; set; }
        public bool lEstado { get; set; }
        public string cCategoria { get; set; }
    }
}
