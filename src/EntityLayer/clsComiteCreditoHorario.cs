using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsComiteCreditoHorario
    {
        public int idComiteCreditoHorario { get; set; }
        public int idEstablecimiento { get; set; }
        public TimeSpan tHoraInicio { get; set; }
        public TimeSpan tHoraFin { get; set; }
        public int nOrden { get; set; }
        public bool lVigente { get; set; }

        public clsComiteCreditoHorario()
        {
            this.idComiteCreditoHorario = 0;
            this.idEstablecimiento = 0;
            this.tHoraInicio = clsVarGlobal.dFecSystem.TimeOfDay;
            this.tHoraFin = clsVarGlobal.dFecSystem.TimeOfDay;
            this.nOrden = 0;
            this.lVigente = true;
        }
    }
}
