using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    public partial class DataUsuarioSentinel
    {

        public int IdUsuarioSentinel { get; set; }
        public int IdUsuarioCore { get; set; }
        public string CUsuario { get; set; }
        public string CContraseña { get; set; }
        public int IdUsuarioModifica { get; set; }
        public DateTime DfechaModifica { get; set; }
        public bool LVigente { get; set; }
    }
}
