using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNCondicionContable
    {
        public clsADCondicionContable objdocide = new clsADCondicionContable();

        public DataTable CNListarCondicionContable()
        {
            //return objdocide.ADListarCondicionContable();
            return objdocide.ADListarCondicionContableXML();
        }

        public DataTable CNListarConCtbProduc(int idProducto)
        {
            return objdocide.ADListarConCtbProduc(idProducto);
        }

        //Lista todos las Condiciones Contables por 'Producto que representan a los Módulos' (Productos con IdProductoPadre NULL)
        //Se usa sólo en el formulario de mantenimiento de 'Configuración de Gastos'
        public DataTable ListarCondicionContablexProducto(int idProducto)
        {
            return objdocide.ListarCondicionContablexProducto(idProducto);
        }

        public DataTable CNListarConCtbModulo(int idModulo)
        {
            return objdocide.ADListarConCtbModulo(idModulo);
        }
        /*================================================================================================================================*/
        /*- Lista las condicion contable por IDs(separados por comas) y modulo. Ejm: 1, '1,3,4,6'                                                */
        /*================================================================================================================================*/
        public DataTable listaCondicionContableXIDs(int idModulo)
        {
            return objdocide.listaCondicionContableXIDs(idModulo);
        }
    }
}
