using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    [XmlInclude(typeof(clsMontoRemesa))]
    public class clsMontoRemesa
    {
        public int idMontoRemesa { set; get; }
        public int idRemesa { set; get; }
        public int idUsuario { set; get; }
        public int idEstadoRemesa { set; get; }
        public decimal nMonto { set; get; }
        public DateTime dFechaRegistro { set; get; }
        public DateTime dFechaHoraRegistro { set; get; }
        public bool lVigente { set; get; }

        public clsMontoRemesa()
        {
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.lVigente = true;
        }
    }
}
