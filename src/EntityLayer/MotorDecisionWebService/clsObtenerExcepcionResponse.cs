using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MotorDecisionWebService
{
    public class clsObtenerExcepcionResponse
    {
        public string mensaje { get; set; }
        public int succes { get; set; }
        public List<clsErrores2> errores { get; set; }
      
    }

    public class clsErrores2 {
        public string codigo { get; set; }
        public string mensaje { get; set; }
    }
}
