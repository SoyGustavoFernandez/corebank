using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCreJorScoreCliente
    {
        public int idScoreCliente { get; set; }
        public int idScoreJornalero { get; set; }
        public int idItem { get; set; }
        public int idValor { get; set; }
        public decimal nValor { get; set; }
        public bool lVigente { get; set; }

        public clsCreJorScoreCliente()
        {
            this.lVigente = true;
        }
    }
}
