using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsClienteExcluidoFSD
    {
        public int idCliExcl { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFinal { get; set; }
        public int idCli { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public int IdTipoPersona { get; set; }
        public int idExcluidoFSD { get; set; }
        public string cExcluidoFSD { get; set; }

        public clsClienteExcluidoFSD()
        {
            this.idCliExcl = 0;
            this.dFechaInicio = DateTime.Now;
            this.dFechaFinal = DateTime.Now;
            this.idCli = 0;
            this.cDocumentoID = string.Empty;
            this.cNombre = string.Empty;
            this.IdTipoPersona = 0;
            this.idExcluidoFSD = 0;
            this.cExcluidoFSD = string.Empty;
        }
    }
}
