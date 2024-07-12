using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsUsuario
    {
        public int idUsuario { get; set; }
        public int idCli { get; set; }
        public DateTime dFechaIngreso { get; set; }
        public Nullable<DateTime> dFechaCese;
        public int idEstado { get; set; }
        public int idCargo { get; set; }
        public string cWinUser { get; set; }
        public bool lChangePass { get; set; }
        public int idAgeCol { get; set; }
        public string cNomUsu { get; set; }
        public string cVersion { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public int idTipoEstablec { get; set; }
        public string cTipoEstablec { get; set; }
        public bool lAutBiometricaAgencia { get; set; }
        public bool lAutBiometricaComite { get; set; }
        public int? nDiasExpiracionSQL { get; set; }
        public bool lVerificacionSMS { get; set; }
        public string cPassword { get; set; }
        public object Clone()
        {
            clsUsuario p = (clsUsuario)this.MemberwiseClone();
            return p;
        }
    }
}
