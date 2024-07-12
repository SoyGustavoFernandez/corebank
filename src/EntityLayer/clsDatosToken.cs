using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class clsDatosToken
    {
        public Guid guidUser;
        public DateTime dInicioSession;
        public DateTime dFechaSistema;
        public int idUsuario;
        public int idAgencia;
        public int idPerfil;
        public int idEstablecimiento;
        public int idTipoEstablecimiento;
        public string cImei;
    }
}
