using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsReglaNegocio
    {
        public int nIdRegla { get; set; }
        public int nIdOpcion { get; set; }
        public string cCaracteristica { get; set; }
        public string cReglaNegocio { get; set; }
        public string cMensajeError { get; set; }
        public int lIndExcepcion { get; set; }
        public string cCampoExcepcion { get; set; }
        public bool lNoExcepcion { get; set; }
        public string cGrupo { get; set; }
        public bool lVigente { get; set; }
        public string cAprobacionCanal { get; set; }
        public string cAcronimo { get; set; }
        public string cNombreCorto { get; set; }
        public int idAprobacionCanal { get; set; }

        public clsReglaNegocio()
        {
            this.nIdRegla = 0;
            this.nIdOpcion = 0;
            this.cCaracteristica = string.Empty;
            this.cReglaNegocio = string.Empty;
            this.cMensajeError = string.Empty;
            this.lIndExcepcion = 0;
            this.cCampoExcepcion = string.Empty;
            this.lNoExcepcion = true;
            this.cGrupo = string.Empty;
            this.lVigente = true;
            this.cAprobacionCanal = string.Empty;
            this.cAcronimo = string.Empty;
            this.cNombreCorto = string.Empty;
            this.idAprobacionCanal = 0;
        }
    }
}
