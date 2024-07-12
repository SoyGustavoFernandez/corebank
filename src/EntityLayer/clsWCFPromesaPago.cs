using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFPromesaPago
    {
        public int idCuenta { get; set; }
        public string dFecha { get; set; }
        public string dFechaRegistrado { get; set; }
        public decimal nMonto { get; set; }
        public string cObservacion { get; set; }
        public string cNombre { get; set; }
        public string cTipoIntervencion { get; set; }
        public string cTelefono { get; set; }
        public int nAtraso { get; set; }
        public string cEstado { get; set; }
    }
}