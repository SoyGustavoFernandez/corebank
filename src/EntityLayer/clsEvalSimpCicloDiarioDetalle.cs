using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsEvalSimpCicloDiarioDetalle
    {
        public int idEvalSimpDetalleCicloDiario { get; set; }
        public int idEvalSimpCicloDiario { get; set; }
        public int idDiaSemana { get; set; }
        public bool lDiaActivo { get; set; }
        public int idTipoCicloDiario { get; set; }
        public decimal nMontoIngreso { get; set; }
        public bool lVigente { get; set; }

        public clsEvalSimpCicloDiarioDetalle()
        {
            idEvalSimpDetalleCicloDiario = 0;
            idEvalSimpCicloDiario = 0;
            idDiaSemana = 0;
            lDiaActivo = false;
            idTipoCicloDiario = 0;
            nMontoIngreso = 0;
            lVigente = false;

        }
    }
}
