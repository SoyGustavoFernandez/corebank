using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsBloqueoCuenta
    {
        public int idBloCta { get; set; }
        public int idCuenta {get; set;}
        public int idBloqueo {get; set;}
        public int idCaracteristicaBloq	 {get; set;}
        public decimal nMonBloqueo {get; set;}
        public string cDesMotivo {get; set;}
        public int idUsuBloq {get; set;}
        public DateTime dFechaBloq {get; set;}
        public bool lBloqueado {get; set;}
        public DateTime dFechaDocBloqueo {get; set;}
        public bool lVigente {get; set;}
        public int idTipoSolicitante {get; set;}
        public string cNombreSolicitante {get; set;}

        public clsBloqueoCuenta()
        {
            this.idBloCta = 0;
            this.idCuenta = 0;
            this.idBloqueo = 0;
            this.idCaracteristicaBloq = 0;
            this.nMonBloqueo = decimal.Zero;
            this.cDesMotivo = string.Empty;
            this.idUsuBloq = clsVarGlobal.User.idUsuario;
            this.dFechaBloq = clsVarGlobal.dFecSystem;
            this.lBloqueado = false;
            this.dFechaDocBloqueo = clsVarGlobal.dFecSystem;
            this.lVigente = false;
            this.idTipoSolicitante = 0;
            this.cNombreSolicitante = string.Empty;
        }
    }
}
