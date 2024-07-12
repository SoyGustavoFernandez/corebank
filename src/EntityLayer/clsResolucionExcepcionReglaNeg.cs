using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsResolucionExcepcionReglaNeg
    {
        public int idResolucionExcepcionReglaNeg { get; set; }
        public int idSolicitud { get; set; }
        public int idEstado { get; set; }
        public int idAprobacionNivel { get; set; }
        public int idAprobacionCanal { get; set; }
        public int idUsuAprobador { get; set; }
        public int idPerfilAprobador { get; set; }
        public string cComentarioAprobador { get; set; }
        public int nCantReglasExcep { get; set; }
        public int nAprobados { get; set; }
        public int nDenegados { get; set; }
        public DateTime dFechaHoraResolucion { get; set; }
        public DateTime dFechaHoraRegistro { get; set; }
        public bool lVigente { get; set; }

        public clsResolucionExcepcionReglaNeg()
        {
            this.idResolucionExcepcionReglaNeg = 0;
            this.idSolicitud = 0;
            this.idEstado = 0;
            this.idAprobacionNivel = 0;
            this.idAprobacionCanal = 0;
            this.idUsuAprobador = 0;
            this.cComentarioAprobador = string.Empty;
            this.nCantReglasExcep = 0;
            this.nAprobados = 0;
            this.nDenegados = 0;
            this.dFechaHoraResolucion = clsVarGlobal.dFecSystem;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.lVigente = true;
        }
    }
}
