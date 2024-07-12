using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFClienteBasico
    {
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        public int idIntervCre { get; set; }
        public int idDireccion { get; set; }
        public string cNombreCliente { get; set; }
        public string cDocumentoID { get; set; }
    }

    public class clsWCFClienteCriterioExpresion
    {
        public int idCli { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreCliente { get; set; }
        public int idTipoDocumento { get; set; }
        public int lReniec { get; set; }
    }
}
