using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetalleSaldoInterviniente
    {
        public int idCliente { get; set; }
        public string cNombre { get; set; }
        public bool lParticipa { get; set; }
        public string cTipoIntervencionCre { get; set; }
        public int idClasificacionInterna { get; set; }
        public string cClasificacionInterna { get; set; }
        public string cCalificativoSBS { get; set; }
        public decimal nSaldoRCC { get; set; }
        public decimal nSaldoMaxRCC { get; set; }
        public string cSaldoMaxRCC { get; set; }
        public string cCalifivativoAvaladoSBS { get; set; }
        public decimal nMoraMax { get; set; }
        public decimal nMoraPromedio { get; set; }
        public string cAvanceDeudaInt { get; set; }
        public string cProductoDestAnt { get; set; }
        public string cProductoDestAct { get; set; }

        public clsDetalleSaldoInterviniente()
        {

        }
    }
}
