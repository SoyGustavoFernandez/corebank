using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /*
     For SP Gen_ListaClienteVinculo_Sp
     */
    public class clsWFCClienteVinculo
    {
        public int idCliVin { get; set; }
        public string cNombre { get; set; }
        public int idTipoVinculo { get; set; }
        public string cTipoVinculo { get; set; }
        public string cDocumentoID { get; set; }
    }
}
