using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{    
    public class clsProductoCredSimp
    {
        public string cNombreProductoCompuesto {
            get
            {
                return cSubProducto + "/" + cProducto+ "/" + cSubTipoProducto + "/" + cTipoProducto;
            }
        }

        public int idSubProducto { get; set; }
        public string cSubProducto { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public int idSubTipoProducto { get; set; }
        public string cSubTipoProducto { get; set; }
        public int idTipoProducto { get; set; }
        public string cTipoProducto { get; set; }
        public int idModuloProducto { get; set; }
        public string cModuloProducto { get; set; }

        public clsProductoCredSimp()
        {
            idSubProducto = 0;
            cSubProducto = string.Empty;
            idProducto = 0;
            cProducto = string.Empty;
            idSubTipoProducto = 0;
            cSubTipoProducto = string.Empty;
            idTipoProducto = 0;
            cTipoProducto = string.Empty;
            idModuloProducto = 0;
            cModuloProducto = string.Empty;
        }
    }
}
