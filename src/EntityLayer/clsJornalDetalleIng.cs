using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsJornalDetalleIng
    {
        public int idEvalJornalDetalleIng { get; set; }
        public int idEvalJornalResumenIng { get; set; }
        public int idDiaSemana { get; set; }
        public bool lIngresoActivo { get; set; }
        public decimal nMontoJornada { get; set; }
        public bool lVigente { get; set; }

        public clsJornalDetalleIng()
        {
            idEvalJornalDetalleIng = 0;
            idEvalJornalResumenIng = 0;
            idDiaSemana = 0;
            lIngresoActivo = false;
            nMontoJornada = 0;
            lVigente = false;

        }
    }
}
