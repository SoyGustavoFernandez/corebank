using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MotorDecisionWebService
{
    public class clsControladorMotorDecision
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public int IdFlujo { get; set; }
        public int IdCliente { get; set; }
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public int ResultadoModelo { get; set; }
        public string FechaSistema { get; set; }

    }
}
