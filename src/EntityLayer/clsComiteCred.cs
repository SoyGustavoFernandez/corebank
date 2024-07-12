using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsComiteCred
    {

        public int idComiteCred { set; get; }
        public string cNomComite { set; get; }
        public string cDescComite { set; get; }
        public int idAgencia { set; get; }
        public string cNombreAge { set; get; }
        public int idEstado { set; get; }

        public string cEstComiteCred
        {
            set { }
            get
            {
                if (idEstado == 1) return "CREADO";
                else if (idEstado == 2) return "INICIADO";
                else if (idEstado == 3) return "FINALIZADO";
                else if (idEstado == 4) return "BLOQUEADO";
                return "";
            }
        }

        public int? idUsuPreside { set; get; }
        public int? idPerfilPreside { set; get; }
        public string cWinUserPreside { set; get; }
        public int idUsuarioReg { set; get; }
        public int idUsuario { set; get; }
        public string cWinUser { set; get; }
        public DateTime? dFecIni { set; get; }
        public DateTime? dFecFin { set; get; }
        public DateTime dFecha { set; get; }
        public bool lVigente { set; get; }
        public List<clsUsuComite> lstParticipantes { set; get; }
        public List<clsEvalCredComite> lstEvalCred { set; get; }
        public int idTipoComiteCred { set; get; }

        public bool lSesionIniciada { get; set; }

        public int nNumEval
        {
            get { return lstEvalCred != null ? lstEvalCred.Count : 0; }
        }

        public int nNumEvalSinDec
        {
            get { return lstEvalCred != null ? lstEvalCred.Count(x => x.idResultado == null) : 0; }
        }

        public int nNumPart
        {
            get { return lstParticipantes != null ? lstParticipantes.Count : 0; }
        }

        public int nNumPartSinConf
        {
            get { return lstParticipantes != null ? lstParticipantes.Count(x => !x.lConfirmAsis) : 0; }
        }

        public int nDuracion { set; get; }

        public string cDuracion
        {
            get
            {
                TimeSpan t = TimeSpan.FromSeconds(nDuracion);

                return string.Format("{0:D2}h:{1:D2}m",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
            }
        }

        public decimal nMontoCreditosTotal
        {
            get
            {
                return this.lstEvalCred.Sum(x=>(decimal)x.nMontoProp);
            }
        }

        public bool ShouldSerializedFecIni()
        {
            return dFecIni != null;
        }

        public bool ShouldSerializedFecFin()
        {
            return dFecFin != null;
        }

        public bool ShouldSerializeidUsuPreside()
        {
            return idUsuPreside != null;
        }

        public bool ShouldSerializeidPerfilPreside()
        {
            return idPerfilPreside != null;
        }
        public bool lAutBiometricaComite { get; set; }

        public clsComiteCred()
        {
            this.idComiteCred = 0;
            this.idAgencia = clsVarGlobal.nIdAgencia;
            this.cNomComite = String.Empty;
            this.cDescComite = String.Empty;
            this.idEstado = 1;
            this.idUsuario = clsVarGlobal.User.idUsuario;
            this.dFecha = clsVarGlobal.dFecSystem.Date;
            this.lVigente = true;

            this.lstParticipantes = new List<clsUsuComite>();
            this.lstEvalCred = new List<clsEvalCredComite>();

            this.idTipoComiteCred = 1;
            this.lSesionIniciada = false;
            this.lAutBiometricaComite = false;
        }

    }
}
