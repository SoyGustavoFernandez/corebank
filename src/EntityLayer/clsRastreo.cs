using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    ///
    /// </summary>
    public class clsRastreo
    {
        public int idRastreo { get; set; }
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        public int idModulo { get; set; }
        public int idAgencia { get; set; }
        public int idMenu { get; set; }
        public int idUsuReg { get; set; }
        public DateTime dFechaSis { get; set; }
        public DateTime dFechaReg { get; set; }
        public string cNomTerminal { get; set; }
        public string cCodMac { get; set; }
        public string cFormulario { get; set; }
        public string cControl { get; set; }
        public string cAccion { get; set; }
        public string cDocumentoID { get; set; }
        public string cIPUsuarioNET { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisRastreo : List<clsRastreo>
    {
    }
}
