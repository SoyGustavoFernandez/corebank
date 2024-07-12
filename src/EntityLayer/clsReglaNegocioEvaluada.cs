using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsReglaNegocioEvaluada : clsReglaNegocio
    {
        public int idUsuRegist { get; set; }
        public string dFecRegist { get; set; }
        public int idTipoOperacion { get; set; }
        public string cCampoExcepcionReemplazado { get; set; }
        public string cTipoOperacion { get; set; }
        public string lAlertaRiesgo { get; set; }
        public string nNumOrden { get; set; }
        public bool lCumplimientoExcepcion { get; set; }
        public string lResul { get; set; }
    }
}
