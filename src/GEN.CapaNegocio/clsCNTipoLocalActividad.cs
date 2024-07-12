using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNTipoLocalActividad
    {
        private clsADTipoLocalActividad objCNTipoLocalActividad = new clsADTipoLocalActividad();

        public DataTable listarTipoLocalActividad(int idProducto)
        {
            return this.objCNTipoLocalActividad.listarTipoLocalActividad(idProducto);
        }
    }
}
