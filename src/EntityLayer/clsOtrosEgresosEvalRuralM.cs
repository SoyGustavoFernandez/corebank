using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOtrosEgresosEvalRuralM
    {
        public Guid idOtrEgrM { get; set; }
        public Guid idOtrIngM { get; set; }
        public int idEvalCred { get; set; }
        public string cNombreInsumo { get; set; }
        public decimal nEgresoTotal { get; set; }
        public int nPlazo { get; set; }
    }
}