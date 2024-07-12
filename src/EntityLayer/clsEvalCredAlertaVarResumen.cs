using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalCredAlertaVarResumen
    {
        public int idEvalCred { get; set; }
        public int idSolicitud { get; set; }
        public int idEstadoSolicitud { get; set; }
        public string cEstadoSolicitud { get; set; }
        public int idUsuResolucion { get; set; }
        public string cUsuResolucion { get; set; }
        public int nAlertas { get; set; }
        public int nSinResolucion { get; set; }
        public int nAprobados { get; set; }
        public int nReconsiderable { get; set; }
        public int nDenegadosRecd { get; set; }
        public int idUsuario { get; set; }
        public string cAsesor { get; set; }
        public int idCli { get; set; }
        public string cCliente { get; set; }
        public decimal nCapitalPropuesto { get; set; }
        public int nCuotas { get; set; }
        public int nPlazoCuota { get; set; }
        public decimal nTEA { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public string cAgencia { get; set; }
        public string cZona { get; set; }
        public DateTime dFechaRegistro { get; set; }

        public clsEvalCredAlertaVarResumen()
        {
            this.idEvalCred = 0;
            this.idSolicitud = 0;
            this.idEstadoSolicitud = 0;
            this.cEstadoSolicitud = string.Empty;
            this.idUsuResolucion = 0;
            this.cUsuResolucion = string.Empty;
            this.nAlertas = 0;
            this.nSinResolucion = 0;
            this.nAprobados = 0;
            this.nReconsiderable = 0;
            this.nDenegadosRecd = 0;
            this.idUsuario = 0;
            this.cAsesor = string.Empty;
            this.idCli = 0;
            this.cCliente = string.Empty;
            this.nCapitalPropuesto = decimal.Zero;
            this.nCuotas = 0;
            this.nPlazoCuota = 0;
            this.nTEA = decimal.Zero;
            this.idProducto = 0;
            this.cProducto = string.Empty;
            this.cAgencia = string.Empty;
            this.cZona = string.Empty;
            this.dFechaRegistro = new DateTime(1990,1,1);
        }
    }
}
