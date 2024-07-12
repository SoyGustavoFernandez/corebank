using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsNotaEntrada
    {
        public int? idOrden { set; get; }
        public int? idTrasferencias { set; get; }
        public int idNotaEntrada { set; get; }
        public string nNroDocumento { set; get; }
        public int idAgencia { set; get; }
        public int idAlmacen { set; get; }
        public int idUsuario { set; get; }
        public int idProveedor { set; get; }
        public int idEstadoLog { set; get; }
        public int idTipIngNotaEntrada { set; get; }
        public decimal nTotal { set; get; }
        public decimal nSubTotal { set; get; }
        public decimal nMontoIGV { set; get; }
        public bool lIncluIGV { set; get; }
        public int nNroNotaEntrada { set; get; }
        public DateTime dFechaReg { set; get; }
        public DateTime? dFechaMod { set; get; }
        public string cMotivo { set; get; }
        public string cProveedor { set; get; }
        public int idComprobantePago { set; get; }
        public decimal nTipoCambio { set; get; }
        public decimal nMontoConvertido { set; get; }
        public int idMoneda { set; get; }
        public int idCliProveedor { set; get; }
        public List<clsDetalleNotaEntrada> lstDetalleNotaEntrada { set; get; }

        public clsNotaEntrada()
        {
            this.idOrden = 0;
            this.idNotaEntrada = 0;
            this.nNroDocumento = string.Empty;
            this.idAgencia = 0;
            this.idAlmacen = 0;
            this.idUsuario = 0;
            this.idProveedor = 0;
            this.idEstadoLog = 0;
            this.idTipIngNotaEntrada = 0;
            this.nTotal = 0;
            this.nSubTotal = 0;
            this.nMontoIGV = 0;
            this.lIncluIGV = false;
            this.nNroNotaEntrada = 0;
            this.dFechaReg = clsVarGlobal.dFecSystem;
            this.cMotivo = string.Empty;
            this.cProveedor = string.Empty;
            this.idComprobantePago = 0;
            this.idCliProveedor = 0;
            //this.nTipoCambio = 0M;
            //this.nMontoConvertido = 0M;
            //this.idMoneda = 0;
            this.lstDetalleNotaEntrada = new List<clsDetalleNotaEntrada>();
        }
    }
}
