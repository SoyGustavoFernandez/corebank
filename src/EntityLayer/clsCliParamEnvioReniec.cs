using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCliParamEnvioReniec
    {
        public clsCliParamEnvioReniec(string _cDocumentoID, int _idUsuario, int _idModulo)
        {
            this.cDocumentoID   = _cDocumentoID;
            this.idUsuario      = _idUsuario;
            this.idModulo       = _idModulo;
        }

        public string cDocumentoID;
        public int idUsuario;
        public int idModulo;
    }
}
