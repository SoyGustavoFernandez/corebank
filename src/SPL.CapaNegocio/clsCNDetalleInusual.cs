using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNDetalleInusual
    {
        public DataTable listarDetalleInusual(int codDetalle)
        {

            clsADDetalleInusual objDetalleInusual = new clsADDetalleInusual();
            return objDetalleInusual.ListarDetalleInusual(codDetalle);

        }

    }
}
