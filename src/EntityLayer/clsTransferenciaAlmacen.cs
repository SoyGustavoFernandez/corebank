using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTransferenciaAlmacen
    {
        public int idTrasferencias { set; get; }
        public int nItem { set; get; }
        public int idAgenciaOri { set; get; }
        public int idAgenciaDes { set; get; }
        public int idAlmacenOri { set; get; }
        public string cAlmacenOri { set; get; }
        public int idAlmacenDes { set; get; }
        public string cAlmacenDes { set; get; }
        public int idUsuarioOri { set; get; }
        public int? idUsuarioDes { set; get; }
        public int idEstado { set; get; }
        public string cEstado { set; get; }
        public bool lVigente { set; get; }
        public DateTime dFechaRegistro { set; get; }
        public DateTime? dFechaRecepcion { set; get; }
        public string cWinUser { set; get; }
        public string cUsuDest { set; get; }
        public int idMoneda { set; get; }

        public List<clsDetTranfAlmacen> lstDetTransf { set; get; }
        public List<clsDetTransferenciasActivo> listaActivosATransferir { set; get; }

        public clsTransferenciaAlmacen()
        {
            this.idTrasferencias = 0;
            this.nItem = 0;
            this.idAgenciaOri = 0;
            this.idAgenciaDes = 0;
            this.idAlmacenOri = 0;
            this.idAlmacenDes = 0;
            this.idUsuarioOri = 0;
            this.idUsuarioDes = 0;
            this.idEstado = Convert.ToInt16(EstLog.SOLICITADO);
            this.lVigente = true;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.lstDetTransf = new List<clsDetTranfAlmacen>();
            this.listaActivosATransferir = new List<clsDetTransferenciasActivo>();
        }
    }

    
}
