using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCreJorReferencia
    {
        public int idReferencia { get; set; }
        public int idScoreJornalero { get; set; }
        public string cNombre { get; set; }
        public string cDireccion { get; set; }
        public string cTelefono { get; set; }
        public int idTipVinculoEval { get; set; }
        public int idTipoReferencia { get; set; }
        public bool lVigente { get; set; }

        public int indexRow { get; set; }

        public clsCreJorReferencia()
        {
            this.lVigente = true;
            this.indexRow = -1;
        }
    }
}
