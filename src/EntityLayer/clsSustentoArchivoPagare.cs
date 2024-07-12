using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSustentoArchivoPagare
    {
        public int idSustentoArchivoPagare { get; set; }
        public int idSolicitud { get; set; }
        public int idSolicitudGrupoSolidario { get; set; }
        public int idCliente { get; set; }
        public bool lSuperaMontoExposicion { get; set; }
        public int idArchivo { get; set; }
        public int idTipoArchivo { get; set; }
        public int idPagareCredito { get; set; }
        public int idEstadoVinculacionArchivo { get; set; }
        public int idMotivoVinculacionArchivo { get; set; }
        public string cComentario { get; set; }
        public int idAccionVinculacionArchivo { get; set; }
        public int idEstadoSolicitud { get; set; }
        public int idEstado { get; set; }
        public int idUsuario { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public bool lVigente { get; set; }
        
        public clsSustentoArchivoPagare()
        {

            idSustentoArchivoPagare         = 0;
            idSolicitud                     = 0;
            idSolicitudGrupoSolidario       = 0;
            idCliente                       = 0;
            lSuperaMontoExposicion          = false;
            idArchivo                       = 0;
            idTipoArchivo                   = 0;
            idPagareCredito                 = 0;
            idMotivoVinculacionArchivo      = 0;
            idEstadoVinculacionArchivo      = 0;
            cComentario                     = String.Empty;
            idAccionVinculacionArchivo      = 0;
            idEstadoSolicitud               = 0;
            idEstado                        = 0;
            idUsuario                       = 0;
            dFechaRegistro                  = clsVarGlobal.dFecSystem;
            lVigente                        = false;
        }
    }
}
