using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.TratamientoUsoDatos.Models
{

    public class AutorizaTratamientoUsoDatos : Auditoria
    {
        public int idAutTraDatos { get; set; }
        public int idCli { get; set; } 
        public int idTipoDocumento { get; set; }

        public string cNroDocumento { get; set; }
        public string cCodCliente { get; set; }
        public string cNomCliente { get; set; }
        public string cDireccion { get; set; }
        public string cCodigoCuenta { get; set; }

        public string cTelefono { get; set; }
        public string cDescripcion { get; set; }
        public int nTiempoVigencia { get; set; }
        public int idRegion { get; set; }
        public string cRegion { get; set; }
        public int idOficina { get; set; }
        public string cOficina { get; set; }
        public int idTipoAutorizacion { get; set; }
        public string cTipoAutorizacion { get; set; }
        public int idCanalRegistro { get; set; }
        public string cCanalRegistro { get; set; }
        public bool lIndicadorConcentimiento { get; set; }

        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }

        public int idEstado { get; set; }
        public string cEstado { get; set; }
        public string cResponsable { get; set; }

        public int idArchivo { get; set; }        
        public string cArchivo { get; set; }
        public byte[] bArchivoBinary { get; set; }     
        public int idModalidad { get; set; }
        public string cModalidad { get; set; }

        public int idMotivo { get; set; }
        public string cMotivo { get; set; }
        public string cUsoRegistro { get; set; }
        public string cFecRegistro { get; set; }
        public DateTime? dFecDesistimiento { get; set; }

        public string cMotDesistimiento { get; set; }
        public string cDescDesistimiento { get; set; }

        public bool lVigente { get; set; } // 0: elimindo, 1 :vigente

        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
    }
}