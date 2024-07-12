using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    public class DataUsuariosUltimaConsulta
    {
        public int? IdUsuarioRegistro { get; set; }
        public int? nCantidadConsultas { get; set; }
        public DateTime? dFechaUltimaConsulta { get; set; }
    }
}
