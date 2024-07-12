using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetTransferenciasActivo
    {
        public bool lSel { get; set; }
        public int? idTrasferencias { get; set; }
        public int idCatalogo { get; set; }
        public string cNomAgencia { get; set; }
        public string cProducto { get; set; }
        public int idActivo { get; set; }
        public int idUsuResp { get; set; }
        public int idAgencia { get; set; }
        public string cSerie { get; set; }
        public string cWinUser { get; set; }

        public int idTipoActivo { set; get; }
        public string cColor { set; get; }
        public string cMaterial { set; get; }
        public string cRubro { set; get; }
        public string cMarca { set; get; }
        public string cModelo { set; get; }
        public decimal nValorActual { set; get; }
        public int idMoneda { set; get; }   
        public clsActivo getActivo()
        {
            clsActivo obj = new clsActivo();
            obj.idActivo  = this.idActivo;
            obj.idTipoActivo  = this.idTipoActivo;
            obj.cColor  = this.cColor;
            obj.cMaterial = this.cMaterial;
            obj.cRubro  = this.cRubro;
            obj.cMarca  = this.cMarca;
            obj.cSerie  = this.cSerie;
            obj.cModelo  = this.cModelo;
            obj.nValorActual = this.nValorActual;
            obj.idMoneda = this.idMoneda;
            return obj;
        }
    }
}
