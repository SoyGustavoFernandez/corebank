using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudAsignada
    {
        public int IdNum { get; set; }
        public int idCuenta { get; set; }
        public string cEstado { get; set; }
        public string cNombre { get; set; }
        public int idCli { get; set; }
        public DateTime Fecha_Desembolso { get; set; }
        public int Frecuencia { get; set; }
        public decimal nMonto { get; set; }
        public int nCuotas { get; set; }
        public int IdMoneda { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public decimal Monto_Cuota { get; set; }
        public int nAtraso { get; set; }
        public string cDocumentoID { get; set; }
        public string cDireccion { get; set; }
        public string cCodCliente { get; set; }
        public string cMoneda { get; set; }
        public int idTipoDocumento { get; set; }
        public bool lGarantia { get; set; }
        public bool lCoberSegDesg { get; set; }
    }
}
