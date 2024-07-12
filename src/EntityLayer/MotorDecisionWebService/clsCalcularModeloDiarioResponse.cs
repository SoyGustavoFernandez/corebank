using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MotorDecisionWebService
{
    public class clsCalcularModeloDiarioResponse
    {
        public clsData data { get; set; }
        public List<clsErrores> errores { get; set; }
        public int succes { get; set; }
        public string comentario { get; set; }
    }

    public class clsData
    {
        public int idPrediccion { get; set; }
        public int num_solicitud { get; set; }
        public Decimal cProbabilidad { get; set; }
        public string cPrediccion { get; set; }
        public DateTime dFechaConsulta { get; set; }
        public decimal nMonto { get; set; }
    }

    public class clsErrores { 
        public string codigo { get; set; }
        public string mensaje { get; set; }
    }

}
