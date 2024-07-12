using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.CPE
{
    public class ProcesoCPE
    {

        public int IdProcesoCPE { get; set; }
        public DateTime FechaIniCPE { get; set; }
        public DateTime FechaFinCPE { get; set; }
        public int NroTotalCPE { get; set; }
        public int NroOkCPE { get; set; }
        public int NroErrorCPE { get; set; }
        public int IdEstadoProcesoCPE { get; set; }
        public string DescripcionEstadoProcesoCPE { get; set; }
        public int NroValida { get; set; }
        public int NroArchivos { get; set; }
        public int IdUsuarioVal { get; set; }
        public DateTime FechaReg { get; set; }
        public int NroAnula { get; set; }

    }
}
