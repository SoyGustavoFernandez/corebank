using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.TratamientoUsoDatos.Models
{   
    public class AutorizaTratamientoUsoDatosDTO : Auditoria
    {
        public int idAutTraDatos { get; set; }
        public int nTiempoVigencia { get; set; }
        public int idTipoAutorizacion { get; set; }
        public string cTipoAutorizacion { get; set; } 
        public bool lIndicadorConcentimiento { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
        public int idEstado { get; set; }
        public string cEstado { get; set; }
        public string cResponsable { get; set; }
        public bool lVigente { get; set; } // 0: elimindo, 1 :vigente
    }
    public class MaestroAutorizacion
    {
        public int idMaestroAutorizacion { get; set; }
        public int idCli { get; set; }
        public int idTipoDocumento { get; set; } 
        public int IdTipoPersona { get; set; }
        public string cNroDocumento { get; set; }
        public string cCodCliente { get; set; }
        public string cNomCliente { get; set; }
        public string cDireccion { get; set; }
        public string cTelefono { get; set; }
        public string cCorreo { get; set; }
        public string cCodigoCuenta { get; set; }
        public string cDescripcion { get; set; }
        public string cArchivo { get; set; }
        public string cArchivoBinary { get; set; }

        public int idModalidad { get; set; }
        public string cModalidad { get; set; }

        public int idTipModAutTraDatos { get; set; }
        public string cTipModAutTraDatos { get; set; } 

        public int idMotivo { get; set; }
        public string cMotivo { get; set; }

        public string cNroDocJuridico { get; set; }
        public string cNombreJuridico { get; set; }

        public int idRegion { get; set; }
        public string cRegion { get; set; }
        public int idOficina { get; set; }
        public string cOficina { get; set; }
        public int idCanalRegistro { get; set; }
        public string cCanalRegistro { get; set; }

        public int idUsuRegistro { get; set; }
        public DateTime dFecRegistro { get; set; }
        public int idUsuModifica { get; set; }
        public DateTime dFecModifica { get; set; }
        public int idMaestroAutOrigen { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public bool lVigente { get; set; }
        public int nTieneCuentasActivas { get; set; }

        
        public List<AutorizaTratamientoUsoDatosDTO> detalleAutorizacion { get; set; }
        public MaestroAutorizacion()
        {
            this.cDireccion =string.Empty;
            this.cTelefono  =string.Empty;
            this.cCorreo    =string.Empty;
        }

    } 
     
}