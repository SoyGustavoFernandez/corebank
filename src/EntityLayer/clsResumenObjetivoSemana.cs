using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsResumenObjetivoSemana
    {
        public int idResumenObjetivoSemana { get; set; }
        public int idPlanTrabajoResumenObjetivo { get; set; }
        public int nSemana { get; set; }
        public bool lVigente { get; set; }
    }
}
