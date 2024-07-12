using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsComprobantePago
    {
        public clsComprobantePago()
        {
            lCpgCajChica = false;
        }

        public string cProveedor { get; set; }
        public string cTipoComprobante { get; set; }
        public int idComprobantePago { get; set; }
        public int? idComprobantePagoTmp { get; set; }
        public int idCliente { get; set; }
        public int idTipoComprobantePago { get; set; }
        public int idMoneda { get; set; }
        public string cSimbolo { get; set; }
        public int idDestino { get; set; }
        public int? idAgencia { get; set; }
        public DateTime? dFechaOpe { get; set; }
        public DateTime? dFechaRegistro { get; set; }
        public DateTime dFechaEmision { get; set; }
        public DateTime? dFechaPago { get; set; }
        public bool lTieneComprobante { get; set; }
        public string cSerie { get; set; }
        public string cNumero { get; set; }
        public int? idBienServicioDetr { get; set; }
        public string cGlosa { get; set; }
        public decimal nSubTotal { get; set; }
        public decimal nTotalIGV { get; set; }
        public decimal? nIgvCalculo { get; set; }
        public decimal nTotal { get; set; }
        public decimal nTotalDetraccion { get; set; }
        public decimal nMontoITF { get; set; }
        public int? idUsuarioRegistro { get; set; }
        public DateTime? dFechaProvision { get; set; }
        public bool lEstadoProvision { get; set; }
        public bool lCpgCajChica { get; set; }
        public int idEstadoComprobante { get; set; }
        public bool? lIndPersonalProveedor { get; set; }
        public int? idAduana { get; set; }
        public bool? lIndNotaCredito { get; set; }
        public bool? lIndAfecRetIGV { get; set; }
        //public string cMotAnul { get; set; }
        public int? IdMotReparoCpg { get; set; }
        public decimal? nTotCredFiscal { get; set; }
        public decimal? nPorcCuartaCateg { get; set; }
        public decimal nTotCuartaCateg { get; set; }
        public decimal nTotOtros { get; set; }
        public decimal? nTipCambio { get; set; }
        public bool? lAfeCuartaCateg { get; set; }
        //public string? cCUO { get; set; }
        public DateTime? dFechaVencimiento { get; set; }
        public bool? lAfecLeyImpRenta { get; set; }
        public DateTime? dFechaDetraccion { get; set; }
        public bool? lIsCierre { get; set; }
        public int idTipoPago { get; set; }

        public int? idComprobanteCoreBank { get; set; }
        public int? idComprobanteViatico { get; set; }
        public string cEstadoComprobante { get; set; }
        public string cDocumentoID { get; set; }
        public bool? lArchivo { get; set; }

        public int? idMsje { get; set; }
        public string cMsje { get; set; }      
    }
}
