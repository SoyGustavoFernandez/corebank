using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigSolicitudCred
    {
        public int idConfigSolicitudCredito { get; set; }
        public int idTipEvalCred { get; set; }
        public string cComponente { get; set; } 
        public string cNombreComponente { get; set; }
        public bool lEditable { get; set; }
        public bool lVigente { get; set; }

        public clsConfigSolicitudCred()
        {
            this.idConfigSolicitudCredito   = 0;
            this.idTipEvalCred              = 0;
            this.cComponente                = String.Empty;
            this.cNombreComponente          = String.Empty;
            this.lEditable                  = false;
            this.lVigente                   = false;
        }
    }
}
