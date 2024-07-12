using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;

namespace EntityLayer
{
    public class clsDepositoCuentaParametro : ICloneable
    {
        public  XmlDocument xmlTipoPago { get; set; }
        public XmlDocument xmlComision { get; set; }
        public int idCuenta { get; set; }
        public decimal nMontoOperacion { get; set; }
        public int idMoneda { get; set; }
        public decimal nMontoComision { get; set; }
        public decimal nMontoITF { get; set; }
        public decimal nMontoRedondeo { get; set; }
        public decimal nMontoCapital { get; set; }
        public int idUsuario { get; set; }
        public int idAgencia { get; set; }
        public DateTime dFechaOperacion { get; set; }
        public int nCuota { get; set; }
        public int idProducto { get; set; }
        public bool lIsAhorroProgramado { get; set; }
        public string cNumeroDocumentoPagare { get; set; }
        public int idEntidadFinanciera { get; set; }
        public int idCuentaTransferencia { get; set; }
        public int idTipoPago { get; set; }
        public int idClienteITF { get; set; }
        public string cDNIClienteOperacion { get; set; }
        public string cNombreClienteOperacion { get; set; }
        public string cDireccionClienteOperacion { get; set; }
        public int idCanal { get; set; }
        public int idMotivoOperacion { get; set; }
        public int idKardexRelacion { get; set; }

        public clsDepositoCuentaParametro()
        {
            xmlTipoPago                     = new XmlDocument();
            xmlComision                     = new XmlDocument();
            idCuenta                        = 0;
            nMontoOperacion                 = Decimal.Zero;
            idMoneda                        = 0;
            nMontoComision                  = Decimal.Zero;
            nMontoITF                       = Decimal.Zero;
            nMontoRedondeo                  = Decimal.Zero;
            nMontoCapital                   = Decimal.Zero;
            idUsuario                       = 0;
            idAgencia                       = 0;
            dFechaOperacion                 = clsVarGlobal.dFecSystem;
            nCuota                          = 0;
            idProducto                      = 0;
            lIsAhorroProgramado             = false;
            cNumeroDocumentoPagare          = String.Empty;
            idEntidadFinanciera             = 0;
            idCuentaTransferencia           = 0;
            idTipoPago                      = 0;
            idClienteITF                    = 0;
            cDNIClienteOperacion            = String.Empty;
            cNombreClienteOperacion         = String.Empty;
            cDireccionClienteOperacion      = String.Empty;
            idCanal                         = 0;
            idMotivoOperacion               = 0;
            idKardexRelacion                = 0;
            xmlDetalleKardex                = new XmlDocument();
        }
        public XmlDocument xmlDetalleKardex { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
