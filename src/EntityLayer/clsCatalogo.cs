using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    [XmlInclude(typeof(clsActivo))]
    public class clsCatalogo
    {
        public int idCatalogo { set; get; }
        public string cCodCatalogo { set; get; }
        public string cProducto { set; get; }
        public int idTipoBien { set; get; }
        public int idSubTipoBien { set; get; }
        public int idGrupo { set; get; }
        public string cNombreGrupo { set; get; }
        public int idSubGrupo { set; get; }
        public int idUnidadCompra { set; get; }
        public string cUnidCompra { set; get; }
        public int idUnidadAlmacenaje { set; get; }
        public string cUnidAlmacenaje { set; get; }
        public decimal nValConversion { set; get; }           
        public bool lIndActivo { set; get; }
        public string cObservacion { set; get; }
        public int idEstado { set; get; }
        public decimal nCantidadTotal { set; get; }
        public decimal nCantidadFisico { set; get; }
        public decimal nCantidadVirtual { set; get; }
        public decimal nPrecioUnit { set; get; }

        public int idUsuReg { set; get; }
        public DateTime dFechaReg { set; get; }   

        public int? idUsuMod { set; get; }
        public DateTime? dFechaMod { set; get; }

        public bool lSelect { set; get; }
        public clsCatalogo()
        {
            this.idCatalogo = 0;
            this.cCodCatalogo = string.Empty;
            this.cProducto = string.Empty;
            this.idTipoBien = 0;
            this.idSubTipoBien = 0;
            this.idGrupo = 0;
            this.cNombreGrupo = string.Empty;
            this.idSubGrupo = 0;
            this.idUnidadCompra = 0;
            this.cUnidCompra = string.Empty;
            this.idUnidadAlmacenaje = 0;
            this.cUnidAlmacenaje = string.Empty;
            this.nValConversion = 0;
            this.lIndActivo = false;
            this.cObservacion = string.Empty;
            this.idEstado = 0;
            this.nCantidadTotal = 0m;
            this.nCantidadFisico = 0m;
            this.nCantidadVirtual = 0m;
            this.nPrecioUnit = 0m;
            this.idUsuReg = clsVarGlobal.User.idUsuario;
            this.dFechaReg = clsVarGlobal.dFecSystem;
            this.lSelect = false;
        }
    }
}
