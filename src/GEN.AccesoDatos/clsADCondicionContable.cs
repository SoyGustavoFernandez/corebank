using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADCondicionContable
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ADListarCondicionContable()
        {
            return objEjeSp.EjecSP("GEN_ListarCondicionContable_sp");
        }
        public DataTable ADListarCondicionContableXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinContable");
        }

        public DataTable ADListarConCtbProduc(int idProducto)
        {
            return objEjeSp.EjecSP("GEN_ListarConCtbProduc_SP", idProducto);
        }

        //Lista todos las Condiciones Contables por 'Producto que representan a los Módulos' (Productos con IdProductoPadre NULL)
        //Se usa sólo en el formulario de mantenimiento de 'Configuración de Gastos'
        public DataTable ListarCondicionContablexProducto(int idProducto)
        {
            return objEjeSp.EjecSP("GEN_ListarCondContableXProd_SP", idProducto);
        }

        public DataTable ADListarConCtbModulo(int idModulo)
        {
            return objEjeSp.EjecSP("GEN_ListarConCtbModulo_SP", idModulo);
        }
        /*================================================================================================================================*/
        /*- Lista las condicion contable por IDs(separados por comas) y modulo. Ejm: 1, '1,3,4,6'                                                */
        /*================================================================================================================================*/
        public DataTable listaCondicionContableXIDs(int idModulo)
        {
            return objEjeSp.EjecSP("CRE_ListaCondicionCtbXid_SP", idModulo);
        }

    }
}
