using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsNotaPedido
    {
        public int idNotaPedido { get; set; }
        public DateTime dFechaNotaPedido { get; set; }
        public int idAgenciaGen { get; set; }
        public string cAgencia { get; set; }
        public int idAreGen { get; set; }
        public string cArea { get; set; }

        public int? idActividad { get; set; }
        public string cActividadLog { get; set; }
        public string cMotivoNotaPedido { get; set; }
        public int idEstadoLog { get; set; }
        public int idMoneda { get; set; }
        public int idTipoPedido { get; set; }
        public int idUsuarioGen { get; set; }
        public string cUsuarioGen { get; set; }
        public DateTime? dFechaMod { get; set; }
        public int? idUsuMod { get; set; }
        public decimal nSubTotal { get; set; }
        public decimal nTotalCosto { get; set; }
        public decimal nTotalConvertido { get; set; }
        public decimal nIGV { get; set; }
        public decimal nMonTipoCambio { get; set; }
        public bool lIncluImpuesto { get; set; }
        public string cNombreEstado { get; set; }
        public int idCli { get; set; }
        public string cUsuarioApro { get; set; }
        public int? idUsuAprob { set; get; } 
        public DateTime? dFechaAprob { get; set; }
        public bool lVigente { get; set; }
        public bool lIndicaConsolidado { get; set; }

        public decimal? nTotalCostoAprobado { get; set; }
        public decimal? nTotalConvertAprob { get; set; }
        public decimal? nMonTipCambioAprob { get; set; }

        public List<clsDetalleNotaPedido> lstDetNotPedido { get; set; }

        public List<clsNotaPedido> lstNotaPedidoConsolid { set; get; }

        public List<clsEvaRequisitosMinimos> lstReqMin { set; get; }

        public clsNotaPedido() : this(0) { }

        public clsNotaPedido(clsNotaPedido objNotPed)
        {
            this.cActividadLog = objNotPed.cActividadLog;
            this.cAgencia = objNotPed.cAgencia;
            this.cArea = objNotPed.cArea;
            this.cMotivoNotaPedido = objNotPed.cMotivoNotaPedido;
            this.cNombreEstado = objNotPed.cNombreEstado;
            this.cUsuarioApro = objNotPed.cUsuarioApro;
            this.cUsuarioGen = objNotPed.cUsuarioGen;
            this.dFechaMod = objNotPed.dFechaMod;
            this.dFechaNotaPedido = objNotPed.dFechaNotaPedido;
            this.idActividad = objNotPed.idActividad;
            this.idAgenciaGen = objNotPed.idAgenciaGen;
            this.idAreGen = objNotPed.idAreGen;
            this.idCli = objNotPed.idCli;
            this.idEstadoLog = objNotPed.idEstadoLog;
            this.idMoneda = objNotPed.idMoneda;
            this.idNotaPedido = objNotPed.idNotaPedido;
            this.idTipoPedido = objNotPed.idTipoPedido;
            this.idUsuarioGen = objNotPed.idUsuarioGen;
            this.idUsuMod = objNotPed.idUsuMod;
            this.nIGV = objNotPed.nIGV;
            this.lIncluImpuesto = objNotPed.lIncluImpuesto;
            this.nMonTipoCambio = objNotPed.nMonTipoCambio;
            this.nTotalConvertido = objNotPed.nTotalConvertido;
            this.nTotalCosto = objNotPed.nTotalCosto;
            this.lIndicaConsolidado = objNotPed.lIndicaConsolidado;
        }

        public clsNotaPedido(int idNotaPedido)
        {
            this.idNotaPedido = idNotaPedido;
            this.cActividadLog = string.Empty;
            this.cAgencia = string.Empty;
            this.cArea = string.Empty;
            this.cMotivoNotaPedido = string.Empty;
            this.cNombreEstado = string.Empty;
            this.cUsuarioApro = string.Empty;
            this.cUsuarioGen = clsVarGlobal.User.cWinUser;
            this.dFechaNotaPedido = clsVarGlobal.dFecSystem;
            this.idActividad = 0;
            this.idAgenciaGen = clsVarGlobal.nIdAgencia;
            this.idAreGen = 0;
            this.idCli = clsVarGlobal.User.idCli;
            this.idEstadoLog = 1;
            this.idMoneda = 1;
            this.idTipoPedido = 0;
            this.idUsuarioGen = clsVarGlobal.User.idUsuario;
            this.nIGV = 0;
            this.lIncluImpuesto = false;
            this.nMonTipoCambio = 0;
            this.nTotalConvertido = 0;
            this.nTotalCosto = 0;
            this.lIndicaConsolidado = false;
            this.lstNotaPedidoConsolid = new List<clsNotaPedido>();
            this.lstDetNotPedido = new List<clsDetalleNotaPedido>();
            this.lstReqMin = new List<clsEvaRequisitosMinimos>();
            this.lVigente = true;
        }
    }
}
