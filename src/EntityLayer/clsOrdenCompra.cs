using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOrdenCompra
    {
        public int idOrden { set; get; }
        public int idTipoOrden { set; get; }
        public int? idTipoProceso { set; get; }
        public int idEstadoLog { set; get; }
        public int? idProceso { set; get; }
        public int idProveedor { set; get; }
        public string cProveedor { set; get; }
        public int idMoneda { set; get; }
        public string cSimbolo { set; get; }
        public string cMoneda { set; get; }
        public DateTime dFechaEmision { set; get; }
        public decimal nSubTotal { set; get; }
        public decimal nMontoTotal { set; get; }
        public decimal nMontoIGV { set; get; }
        public decimal nMonConvertido { set; get; }
        public decimal nTipoCambio { set; get; }
        public int? idFormaPago { set; get; }
        public string cLugarEntrega { set; get; }
        public string cObservacion { set; get; }
        public int idUsuReg { set; get; }        
        public DateTime dFechaReg { set; get; }
        public int? idUsuMod { set; get; }
        public DateTime? dFechaMod { set; get; }
        public int idTipoPago { set; get; }
        public int idAlmacenEntrega { set; get; }
        public int idAgencia { set; get; }
        public bool lIncluIGV { set; get; }
        public bool lVigente { set; get; }
        public int idCli { set; get; }
        public int nGrupo { get; set; }
        public int idNotaEntrada { get; set; }
        public string cSustento { set; get; }

        public List<clsDetalleOrdenCompra> lstDetOrdenCompra { set; get; }

        public clsOrdenCompra()
        {
            idOrden = 0;
            idTipoOrden = 0;
            idTipoProceso = 0;
            idEstadoLog = 0;
            idProceso = 0;
            idProveedor = 0;
            idMoneda = 0;
            cSimbolo = string.Empty;
            cMoneda = string.Empty;
            dFechaEmision = clsVarGlobal.dFecSystem;
            nMontoTotal = 0;
            nMontoIGV = 0;
            nTipoCambio = 0;
            idFormaPago = 0;
            cLugarEntrega = string.Empty;
            cObservacion = string.Empty;
            idUsuReg = clsVarGlobal.User.idUsuario;
            dFechaReg = clsVarGlobal.dFecSystem;
            idTipoPago = 0;
            idAlmacenEntrega = 0;
            lVigente = true;
            idCli = 0;
            lstDetOrdenCompra = new List<clsDetalleOrdenCompra>();
            idNotaEntrada = 0;
            cSustento = string.Empty;
        }
    }
}
