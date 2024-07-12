using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAgenciaEstablecimiento
    {
        public int idRegion { get; set; }
        public int idEstablecimiento { get; set; }
        public int idAgencia { get; set; }
        public string cAgencia { get; set; }
        public string cEstablecimiento { get; set; }
        public int idTipoEstablecimiento { get; set; }

        public clsAgenciaEstablecimiento()
        {
            this.idRegion = 0;
            this.idEstablecimiento = 0;
            this.idAgencia = 0;
            this.cAgencia = string.Empty;
            this.cEstablecimiento = string.Empty;
            this.idTipoEstablecimiento = 0;
        }
    }
}
