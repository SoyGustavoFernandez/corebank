using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsProveedores
    {
        public int idProveedor { get; set; }
        public int idCli { set; get; }
        public string cCtaDetraccion { set; get; }
        public string cCuentaCorriente { set; get; }
        public string cNombre { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreComercial { get; set; }
        public string cDireccion { set; get; }
        public int IdTipoPersona { set; get; }
        public string cCodCliente { set; get; }
        public int idTipoDocumento { set; get; }
       //public string cRubro { get; set; }
    }
   public class clsListaProveedores : BindingList<clsProveedores>
   {
   }
}
