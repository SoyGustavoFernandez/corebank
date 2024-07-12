using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTasaNegociable
    {
        public int idTasaNegociada { get; set; }
        public int idTasa { get; set; }
        public int idSolicitud { get; set; }
        public DateTime dFechaReg { get; set; }
        public string cUsuAprueba { get; set; }
        public decimal nTasaSolicitada { get; set; }
        public decimal nTasaAprobada { get; set; }
        public decimal nTasaMoratoriaSol { get; set; }
        public int idEstado { get; set; }
        public string cDescEstado { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public int nCuotas { get; set; }
        public string cDescripTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public int nCuotasGracia { get; set; }
        public DateTime FechaDesembolso { get; set; }

        public int idUsuReg {get; set;}
        public string cUsuReg {get; set;}
        public string cJustificacion {get; set;}
		public int idUsuPreAprueba {get; set;}
        public string cUsuPreAprueba {get; set;}
        public string cJustificacionPreAproba {get; set;}
		public int idUsuAprueba {get; set;}
		public string cJustificacionAprobacion {get; set;}

        public decimal nTasaPreAprobada { get; set; }

    }
}
