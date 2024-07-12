using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsExcepReglaNegResum
    {
        public int idSolicitud { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idUsuario { get; set; }
        public string cUsuario { get; set; }
        public int idCli { get; set; }
        public string cCliente { get; set; }
        public int idOperacion { get; set; }
        public string cOperacion { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public decimal nMonto { get; set; }
        public int nPlazoCuota { get; set; }
        public int nCuotas { get; set; }
        public decimal nTasa { get; set; }
        public int ndiasgracia { get; set; }
        public int idAgencia { get; set; }
        public string cAgencia { get; set; }
        public int nReglas { get; set; }
        public int nSolicitados { get; set; }
        public int nDerivados { get; set; }
        public int nAprobados { get; set; }
        public int nDenegados { get; set; }

        public clsExcepReglaNegResum()
        {
            this.idSolicitud = 0;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.idUsuario = 0;
            this.cUsuario = string.Empty;
            this.idCli = 0;
            this.cCliente = string.Empty;
            this.idOperacion = 0;
            this.cOperacion = string.Empty;
            this.idProducto = 0;
            this.cProducto = string.Empty;
            this.nMonto = decimal.Zero;
            this.nPlazoCuota = 0;
            this.nCuotas = 0;
            this.nTasa = decimal.Zero;
            this.ndiasgracia = 0;
            this.idAgencia = 0;
            this.cAgencia = string.Empty;
            this.nReglas = 0;
            this.nSolicitados = 0;
            this.nDerivados = 0;
            this.nAprobados = 0;
            this.nDenegados = 0;
        }
    }
}
