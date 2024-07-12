using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsParametroAprobTasaNegociable
    {
        public int idParametroAprobTasaNegociable { get; set; }
        public int idTipoTasa { get; set; }
        [XmlIgnore]
        public string cTipoTasa { get; set; }
        public int nNumeroVistoBueno { get; set; }
        public bool lVigente { get; set; }

        public clsParametroAprobTasaNegociable()
        {
            idParametroAprobTasaNegociable  = 0;
            idTipoTasa                      = 0;
            cTipoTasa                       = String.Empty;
            nNumeroVistoBueno               = 0;
            lVigente                        = false;
        }
    }
}
