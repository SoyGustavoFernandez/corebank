using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEN.ControlesBase.Model
{

    public class DocumentosFirma : clsAuditoria
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idTipoPersona { get; set; }
        public int idGrupoArchivo { get; set; }
        public string cArchivoExpediente { get; set; }
        public string cNombresArchivo { get; set; }
        public bool lObligatorio { get; set; } 
 
        public int idEstado { get; set; } 
        public string cEstado { get; set; }
        public string cRutaDocumento { get; set; }  
        
        public bool lVigente { get; set; } // 0: elimindo, 1 :vigente
    }
}