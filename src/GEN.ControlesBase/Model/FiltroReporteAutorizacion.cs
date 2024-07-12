using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEN.ControlesBase.Model
{
    public class FiltroReporteAutorizacion
    {
        public int idTipoAutorizacion { get; set; }
        public int idOficina { get; set; }
        public int idRegion { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecInicio { get; set; }
        public DateTime dFecFin { get; set; }        
    }
}