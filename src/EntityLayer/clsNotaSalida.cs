using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsNotaSalida
    {
        public int idNotaSalida { set; get; }
        public int idActividadLog { set; get; }
        public string cActividadLog { set; get; }
        public int idDestinoPedido { set; get; }
        public int idAlmacen { set; get; }
        public string cNombreAlmacen { set; get; }
        public int idArea { set; get; }
        public string cArea { set; get; }
        
        public int idEstadoLog { set; get; }
        public string cEstLog { set; get; }
        public int nNroNotaSalida { set; get; }

        public int idUsuReg { set; get; }
        public string cUsuReg { set; get; }
        public DateTime dFechaRegistro { set; get; }
        public int idAgenciaReg { set; get; }
        public string cAgenciaReg { set; get; }

        public int idAgenAlmacen { set; get; }
        public string cNomAgenAlmacen { set; get; }

        public int idCli { set; get; }

        public int? idUsuMod { set; get; }
        public string cUsuMod { set; get; }
        public DateTime? dFechaMod { set; get; }

        public int? idUsuAprob { set; get; }
        public string cUsuAprob { set; get; }
        public DateTime? dFechaAprobacion { set; get; }
        public int? idAgenciaAprob { set; get; }

        public int? idUsuAten { set; get; }
        public string cUsuAten { set; get; }
        public DateTime? dFechaAten { set; get; }
        public int? idAgenciaAten { set; get; }
        public string cSustento { set; get; }

        public List<clsDetNotaSalida> LstDetNotSalida { set; get; }

        public clsNotaSalida(int idNotaSalida)
        {
            this.idNotaSalida = idNotaSalida;
            this.idActividadLog = 0;
            this.idDestinoPedido = 0;
            this.idAlmacen = 0;
            this.idArea = 0;
            this.idEstadoLog = 0;
            this.cEstLog = string.Empty;
            this.nNroNotaSalida = 0;
            this.idUsuReg = clsVarGlobal.User.idUsuario;
            this.cUsuReg = clsVarGlobal.User.cWinUser;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            /*this.cSustento = string.Empty;*/
            LstDetNotSalida = new List<clsDetNotaSalida>();
        }

        public clsNotaSalida() : this(0) { }
    }

    public enum EstLog
    {
        TODOS = -1,
        SOLICITADO = 1,
        APROBADO = 2,
        ATENDIDO = 3,
        DENEGADO = 4,
        EN_ADQUISICIÓN = 5,
        PENDIENTE = 6,
        EN_EVALUACIÓN = 7,
        CONSOLIDADO = 8,
    }
}
