using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MotorDecisionWebService
{
    public class clsObtenerExcepcionRequest
    {
        public int nNumeroSolicitud { get; set; }
        public string dFechaP { get; set; }
        public decimal nMontoSolicitado { get; set; }
        public int nPlazo { get; set; }
        public string cMotivoRechazo { get; set; }
    }
}
