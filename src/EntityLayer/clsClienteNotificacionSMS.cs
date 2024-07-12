using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsClienteNotificacionSMS : ICloneable
    {
        public int idCliente { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreCompleto { get; set; }
        public int idRegistro { get; set; }
        public int idModulo { get; set; }
        public List<clsRegistroTelefono> lstRegistroTelefono { get; set; }


        public clsClienteNotificacionSMS()
        {
            idCliente = 0;
            cDocumentoID = String.Empty;
            cNombreCompleto = String.Empty;
            lstRegistroTelefono = new List<clsRegistroTelefono>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
