using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsIntervinienteCuenta
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public int idTipoInterv { get; set; }
        public string cTipoIntervencion { get; set; }
        public bool lCliAfeITF { get; set; }
        public bool isReqFirma { get; set; }
        public string cTipoDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public int idTipoPersona { get; set; }
        public int nEdadCli { get; set; }

        public clsIntervinienteCuenta()
        {
            this.idSolicitud = 0;
            this.idCli = 0;
            this.cDocumentoID = string.Empty;
            this.cNombre = string.Empty;
            this.idTipoInterv = 0;
            this.cTipoIntervencion = string.Empty;
            this.lCliAfeITF = false;
            this.isReqFirma = false;
            this.cTipoDocumento = string.Empty;
            this.idTipoDocumento = 0;
            this.idTipoPersona = 0;
            this.nEdadCli = 0;
        }
    }
}
