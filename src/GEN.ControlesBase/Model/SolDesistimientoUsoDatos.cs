using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEN.ControlesBase.Model
{

    public class SolDesistimientoUsoDatos : clsAuditoria
    {
        public int idSolDesentimiento { get; set; }
        public int idAutTraDatos { get; set; }
        public int idCli { get; set; }
        public string cMotivo { get; set; }
        public int idRegion { get; set; }
        public string cRegion { get; set; }
        public int idOficina { get; set; }
        public string cOficina { get; set; }

        public int idTipoAutorizacion { get; set; }
        public string cTipoAutorizacion { get; set; }
        public int idCanalRegistro { get; set; }
        public string cCanalRegistro { get; set; }

        public string cArchivo { get; set; }
        public byte[] bArchivoBinary { get; set; }
        public int idModalidad { get; set; }
        public string cModalidad { get; set; }

        public int idMotivoNoFirma { get; set; }
        public string cMotivoNoFirma { get; set; }
        public bool lVigente { get; set; } // 0: elimindo, 1 :vigente
    }
}