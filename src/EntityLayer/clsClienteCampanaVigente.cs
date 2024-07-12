using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsClienteCampanaVigente
    {
        public int idDetalle { get; set; }
        public int idCreditosPreAprobados { get; set; }
        public int idCli { get; set; }
        public int idGrupoCamp { get; set; }
        public string cGrupoCamp { get; set; }
        public int idTipoGrupoCamp { get; set; }
        public string cTipoGrupoCamp { get; set; }
        public int idDestino { get; set; }
        public string cDestino { get; set; }
        public int nPlazo{ get; set; }
        public decimal nMonto { get; set; }
        public bool lVigente { get; set; }
        public string cNombre { get; set; }
		public string cDireccion{ get; set; }
        public int idDireccion { get; set; }
        public decimal nTasa { get; set; }
    }
}
