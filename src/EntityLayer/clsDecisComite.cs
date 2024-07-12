using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDecisComite
    {
        public bool lResponsable { set; get; }

        public int idUsuComite { set; get; }

        public string cNombre { set; get; }

        public string cWinUser { set; get; }

        public int idTipoParticip { set; get; }

        public string cTipoParticip { set; get; }

        public bool lDecision { set; get; }

        public int idCargo { set; get; }

        public string cDecision
        {
            get { return (lDecision == true) ? "Favorable" : "Desfavorable"; }
        }
    }
}
