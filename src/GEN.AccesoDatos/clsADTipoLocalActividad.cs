using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoLocalActividad
    {
        private clsGENEjeSP objGENEjeSP = new clsGENEjeSP();

        public DataTable listarTipoLocalActividad(int idProducto)
        {
            return this.objGENEjeSP.EjecSP("CRE_ListarTipoLocalActividad_SP", idProducto);
        }
    }
}
