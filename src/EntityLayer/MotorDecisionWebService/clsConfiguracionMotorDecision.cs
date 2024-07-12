using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MotorDecisionWebService
{
    public class clsConfiguracionMotorDecision
    {
        public int Id { get; set; }
        public int IdRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string Comentario { get; set; }
    }
}
