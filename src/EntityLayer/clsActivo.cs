using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsActivo : clsCatalogo
    {
        public int idActivo { set; get; }
        //public clsCatalogo objCatalogo { set; get; }
        public int idTipoActivo { set; get; }
        public string cColor { set; get; }
        public string cMaterial { set; get; }
        public string cRubro { set; get; }
        public string cMarca { set; get; }
        public string cSerie { set; get; }
        public string cModelo { set; get; }    
        public DateTime? dFechaActivacion { set; get; }       
        public DateTime dFechaCompra { set; get; }
        public int idEstadoActivo { set; get; }
        public decimal nPorcDeprec { set; get; }
        public decimal nMontoDeprec { set; get; }
        public decimal nValorActual { set; get; }
        public int idCliProveedor { set; get; }
        public string cDocProveedor { set; get; }
        public string cDetalleCpg { set; get; }
        public string cSerieCpg { set; get; }
        public string cNumeroCpg { set; get; }
        public int idTipComPag { set; get; }
        public string cUbicActivo { set; get; }
        public int idUsuOrig { set; get; }
        public int idAgenciaOrig { set; get; }

        public int idUsuResp { set; get; }
		public int idNotaEntrada { set; get; }
		public string cCodInstActivo { set; get; }
		public string cObsActiv	{ set; get; }
        public decimal nValorCompra { set; get; }
        
        //public int idUsuReg { set; get; }        
        public string cNombreColResp { set; get; }
        public string cNomProveedor { set; get; }
        public int idAgencia { set; get; }

        public int idUsuBaja { set; get; }
        public int? idMotBajaActivo { set; get; }
        public string cObservacionBaja { set; get; }
        public DateTime? dFechaBaja { set; get; }
        public int idMoneda { set; get; }
        public decimal nAdquisicionAdicion { set; get; }
        public decimal nMejoras { set; get; }
        public decimal nAjusteInflacion { set; get; }

        public clsActivo():this(0)
        {
        }

        public clsActivo(int IdActivo)
        {
            this.idActivo = IdActivo;
            //this.objCatalogo = new clsCatalogo();
            this.idTipoActivo = 0;
            this.cColor = string.Empty;
            this.cMaterial = string.Empty;
            this.cRubro = string.Empty;
            this.cMarca = string.Empty;
            this.cSerie = string.Empty;
            this.cModelo = string.Empty;
            this.cObservacionBaja = string.Empty;
            this.dFechaActivacion = clsVarGlobal.dFecSystem;
            this.idEstadoActivo = 0;
            this.dFechaCompra = clsVarGlobal.dFecSystem;
            this.nPorcDeprec = 0;
            this.nMontoDeprec = 0;
            this.nValorActual = 0;
            this.idCliProveedor = 0;
            this.cDetalleCpg = string.Empty;
            this.cSerieCpg = string.Empty;
            this.cNumeroCpg = string.Empty;
            this.idTipComPag = 0;
            this.idMotBajaActivo = 0;
            this.idUsuBaja = 0;
            this.idUsuReg = 0;
            this.idAgencia = 0;
            this.idMoneda = 0;
            this.dFechaBaja = clsVarGlobal.dFecSystem;
            this.cNombreColResp = string.Empty;
            this.cNomProveedor = string.Empty;
            this.lIndActivo = true;
            this.nAdquisicionAdicion = 0;
            this.nMejoras = 0;
            this.nAjusteInflacion = 0;
        }
    }
}
