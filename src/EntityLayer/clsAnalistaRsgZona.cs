using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAnalistaRsgZona
    {
        public int idAnalistaRsgZona { get; set; }
        public int idZona { get; set; }
        public int idUsuarioAnalista { get; set; }
        public String cDesZona { get; set; }
        public String cNombre { get; set; }
    }
}
