using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOtrosGastos
    {
        public long idCuenta { get; set; }
        public int idCuota { get; set; }
        public int idTipoGasto { get; set; }
        public decimal nGasto { get; set; }
        public decimal nGastoPag { get; set; }
        public int idPlanPagos { get; set; }
    }
}
