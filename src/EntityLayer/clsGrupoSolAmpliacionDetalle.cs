using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGrupoSolAmpliacionDetalle
    {
        public int idGrupoSolAmpliacionDetalle { get; set; }
        public int idGrupoSolidarioAmpliacion { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        public int idCuentaAmpliada { get; set; }
        public int idSolicitud { get; set; }
        public int idSolicitudOrigen { get; set; }
        public int idSolicitudAnterior { get; set; }
        public int idEstado { get; set; }
        public decimal nSaldoCapital { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public decimal nMontoSolicitud
        {
            get
            {
                return (this.nSaldoCapital + this.nMontoAmpliado);
            }
        }

        public clsGrupoSolAmpliacionDetalle()
        {
            this.idGrupoSolAmpliacionDetalle = 0;
            this.idGrupoSolidarioAmpliacion = 0;
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idCli = 0;
            this.idCuenta = 0;
            this.idCuentaAmpliada = 0;
            this.idSolicitud = 0;
            this.idSolicitudOrigen = 0;
            this.idSolicitudAnterior = 0;
            this.idEstado = 0;
            this.nSaldoCapital = decimal.Zero;
            this.nMontoAmpliado = decimal.Zero;
        }
    }
}
