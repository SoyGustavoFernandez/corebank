using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGrupoSolIntegranteCtaAhorro
    {
        public int idSolicitud { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idCliente { get; set; }
        public int idCuentaAhorro { get; set; }
        public decimal nSaldoDisponible { get; set; }

        public clsGrupoSolIntegranteCtaAhorro()
        {
            this.idSolicitud = 0;
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idCliente = 0;
            this.idCuentaAhorro = 0;
            this.nSaldoDisponible = decimal.Zero;
        }
    }
}
