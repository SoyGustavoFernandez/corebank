using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsTasaNegociadaPerfil
    {
        public int idTipoTasa { get; set; }
        [XmlIgnore]
        public string cTipoTasa { get; set; }
        public int idPerfil { get; set; }
        [XmlIgnore]
        public string cPerfil { get; set; }
        public bool lVigente { get; set; }
        public clsTasaNegociadaPerfil()
        {
            idTipoTasa  = 0;
            cTipoTasa   = String.Empty;
            idPerfil    = 0;
            cPerfil     = String.Empty;
            lVigente    = false;
        }
    }
}
