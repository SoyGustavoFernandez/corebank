using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFMonitorVisita
    {
        public int idVisita { get; set; }
        public int idTipoVisita { get; set; }
        public string cNombreTipoVisita { get; set; }
        public int idEstadoVisita { get; set; }
        public string cNombreEstadoVisita { get; set; }
        public string cObservacion { get; set; }
        public string dtFechaVisita { get; set; }
        public string cNombreUsuario { get; set; }
        public string cNombreCliente { get; set; }
        public int idCli { get; set; }
        public double nLatitude { get; set; }
        public double nLongitude { get; set; }
        public int idAgencia { get; set; }
        public string cNombreAge { get; set; }
        public bool lTieneCredito { get; set; }
        public int nAtraso { get; set; }
        public decimal nCapitalDesembolso { get; set; }
    }

    public class clsWCFMonitorCredito
    {
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        public string cProducto { get; set; }
        public string dFechaDesembolso { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public decimal nSaldoCapitalNormal { get; set; }
        public decimal nSaldoCapitalVenc { get; set; }
        public int nAtraso { get; set; }
    }

    public class clsWCFMonitorListaZona
    {
        public int idZona { get; set; }
        public string cDesZona { get; set; }
    }

    public class clsWCFMonitorListaAgencia
    {
        public int idAgencia { get; set; }
        public string cNombreAge { get; set; }
    }

    public class clsWCFMonitorPersonal
    {
        public int idUsuario { get; set; }
        public string cNombre { get; set; }
    }

    public class clsWCFMonitorListaArchivo
    {
        public int idArchivos { get; set; }
        public string cNombreArchivo { get; set; }
        public int idTipoArchivo { get; set; }
    }

    public class clsWCFMonitorArchivo
    {
        public string cNombreArchivo { get; set; }
        public string cArchivo { get; set; }
        public string cDetalleArchivo { get; set; }
    }

    public class clsWCFMonitorVisitaRespuesta
    {
        public IList<clsWCFMonitorVisita> listaBusqueda { get; set; }
        public clsWCFRespuesta oRespuesta { get; set; }
    }
}
