using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudProcesoAdquisicion
    {
         public int idProcAdq { set; get; }


        public int idArea { set; get; }
        public string cArea { set; get; }
        
        public int idEstadoLog { set; get; }
        public string cEstLog { set; get; }
        public int nNroProcAdq { set; get; }

        public int idUsuReg { set; get; }
        public string cUsuReg { set; get; }
        public string cNombreUsuReg { set; get; }
        public string cEstadoUsu { set; get; }
        public DateTime dFechaRegistro { set; get; }
        public int idAgenciaReg { set; get; }
        public string cAgenciaReg { set; get; }
        public int idCli { set; get; }

        public int? idUsuMod { set; get; }
        public string cUsuMod { set; get; }
        public DateTime? dFechaMod { set; get; }

        public int? idUsuAprob { set; get; }
        public string cUsuAprob { set; get; }
        public DateTime? dFechaAprobacion { set; get; }
        public int? idAgenciaAprob { set; get; }
        public string cSustento { set; get; }
        public int idMoneda { get; set; }
        public int idProveedor { get; set; }

        public bool lIgv { get; set; }
        public int idTipoComprobante { get; set; }
        public string cObservacion { get; set; }

        public List<clsDetProcesoAdquisicion> LstDetProcAdq { set; get; }

        public clsSolicitudProcesoAdquisicion(int idProcAdq)
        {
            this.idProcAdq = idProcAdq;
            this.idArea = 0;
            this.idEstadoLog = 0;
            this.cEstLog = string.Empty;
            this.nNroProcAdq = 0;
            this.idProveedor = 0;
            this.idUsuReg = clsVarGlobal.User.idUsuario;
            this.cUsuReg = clsVarGlobal.User.cWinUser;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            LstDetProcAdq = new List<clsDetProcesoAdquisicion>();
        }

        public clsSolicitudProcesoAdquisicion() : this(0) { }
    }
}
