using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolCredGSIntegrante
    {
        public int idSolicitud { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idCli { get; set; }
        public int idOperacion { get; set; }
        public decimal nMonto { get; set; }
        public int idDestino { get; set; }
        public int idDetalleGasto { get; set; }

        public int idEstadoSol { get; set; }
        public bool lReglas { get; set; }
        public int nExcepciones { get; set; }
        public string cProcesado { get; set; }
        public string cNombreCompleto { get; set; }

        public clsSolCredGSIntegrante()
        {
            this.idSolicitud = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idCli = 0;
            this.idOperacion = 0;
            this.nMonto = decimal.Zero;
            this.idDestino = 0;
            this.idDetalleGasto = 0;

            this.idEstadoSol = 0;
            this.lReglas = false;
            this.nExcepciones = 0;
            this.cProcesado = string.Empty;
            this.cNombreCompleto = string.Empty;
        }
    }
}
