﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.TratamientoUsoDatos.Models
{

    public class SolDesistimientoUsoDatosDTO : Auditoria
    {
        public int idSolDesentimiento { get; set; }
        public int idAutTraDatos { get; set; }
        public int idCli { get; set; }
        public int idMotivoDesistimiento { get; set; }
        public string cDescripcion { get; set; } 
        public int idRegion { get; set; } 
        public string cRegion { get; set; } 
        public int idOficina { get; set; } 
        public string cOficina { get; set; } 

        public int idTipoAutorizacion { get; set; }
        public string cTipoAutorizacion { get; set; }
        public int idCanalRegistro { get; set; }
        public string cCanalRegistro { get; set; }
        public string cArchivo { get; set; }
        public string cArchivoBinary { get; set; }

        public int idModalidad { get; set; }
        public string cModalidad { get; set; }

        public int idMotivoNoFirma { get; set; }
        public string cMotivoNoFirma { get; set; }
        public bool lVigente { get; set; } // 0: elimindo, 1 :vigente
    }
}