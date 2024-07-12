using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudReprogramacion
    {
        public int idSoliCambio { get; set; }
        public int idSolicitud { get; set; }
        public int idSolicitudOrigen { get; set; }
        public int nCuotasOrigen { get; set; }
        public int nCuotasDestino { get; set; }
        public int idCuotaOrigen { get; set; }
        public int idEstadoSolicitud { get; set; }
        public int idCuenta { get; set; }
        public int idOperacion { get; set; }
        public int idTasaDestino { get; set; }
        public decimal nSaldoCapitalOrigen { get; set; }
        public decimal nCapitalAprobado { get; set; }
        public int nAtrasoCuota { get; set; }
        public int idTipoPlanPago { get; set; }
        public int idTasa { get; set; }
        public decimal nTasaCompensatoriaOrigen { get; set; }
        public int idEstadoSolTasa { get; set; }

        public clsSolicitudReprogramacion()
        {
            this.idSoliCambio = 0;
            this.idSolicitud = 0;
            this.idSolicitudOrigen = 0;
            this.nCuotasOrigen = 0;
            this.nCuotasDestino = 0;
            this.idCuotaOrigen = 0;
            this.idEstadoSolicitud = 0;
            this.idCuenta = 0;
            this.idOperacion = 0;
            this.idTasaDestino = 0;
            this.nSaldoCapitalOrigen = decimal.Zero;
            this.nCapitalAprobado = decimal.Zero;
            this.nAtrasoCuota = 0;
            this.idTipoPlanPago = 0;
            this.idTasa = 0;
            this.nTasaCompensatoriaOrigen = decimal.Zero;
            this.idEstadoSolTasa = 0;
        }
    }
}
