using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsVarFlujoCajaEval
    {
        public int idVarFlujoCajaEval { get; set; }
        public int idEEFF { get; set; }
        public DateTime dFechaInicio { get; set; }

        public int nMes { get; set; }

        public DateTime dFecha
        {
            get 
            {
                return dFechaInicio.AddMonths(nMes);
            }
        }

        public decimal nMonto { get; set; }
        public decimal nPorcentaje { get; set; }
        public string cPorcentaje { get; set; }

        public clsVarFlujoCajaEval()
        {
            nMes = 1;
            nPorcentaje = 100;
            cPorcentaje = "%";
        }
    }
}
