using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityLayer
{
    public class clsMantenimientoPaqueteSeguro
    {
        public string cNombreCorto { set; get; }
        public string cNombreCompleto { set; get; }
        public decimal nPrecio { set; get; }
        public int idMoneda { set; get; }
        public string cLink { set; get; }
        public string cCorreoReporte { set; get; }
        public int idSeguro { set; get; }
        public string cSeguro { set; get; }
        public string cSeguroCorto { set; get; }
        public int nSeguroComplementario { set; get; }
        public bool lvigenteSeguro { set; get; }
        public int idPaqueteSeguro { set; get; }
        public int idEstablecimiento { set; get; }
        public bool EstadoEstablecimiento { set; get; }
        public int idPerfil { set; get; }
        public bool cEstado { set; get; }
        public int nFiltro { set; get; }
        public int idDetalleGasto { set; get; }
        public int idUsuario { set; get; }
        public int idConcepto{ get; set; }
        public bool selecciona { get; set; }
        public int orden { get; set; }
        public bool lvigente { get; set; }
        public int idConceptoDetalleGasto { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaFinRegistro { get; set; }
        public int idTipoSeguro             {get;set;}
        public string cNombreAdicional { get;set;}
        

        public List<clsSeguroComplementario> listaSeguroCommplementario = new List<clsSeguroComplementario>();
        public List<clsPlanTrabajoZonaVisita> listaPaqueteSeguroZona = new List<clsPlanTrabajoZonaVisita>();
        public List<clsAgencia> listaPaqueteSeguroEstablecimiento = new List<clsAgencia>();
        public List<clsPerfil> listaPaqueteSeguroPerfil = new List<clsPerfil>();
    }
    
}