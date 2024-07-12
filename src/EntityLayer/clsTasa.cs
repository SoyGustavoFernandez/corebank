using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTasa
    {
        public int idTasa { get; set; }
        public int idPlazo { get; set; }
        public int idProducto { get; set; }
        public int idMonto { get; set; }
        public int idMoneda { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public bool lVigente { get; set; }
        public int idAgencia { get; set; }
        public int idTipoPersona { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public bool EnUso { get; set; }
        public int idTipoTasa { get; set; }
        public bool lNegociable { get; set; }
        public string cDescripcion { get; set; }
        public decimal nTasaNegAprobada { get; set; }
        public decimal nTasaMoratoriaAproba { get; set; }
    }
}
