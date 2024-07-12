using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoTransaccion
    {
        clsADTipoTransaccion objlistaTipoTransac = new clsADTipoTransaccion();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListarTipoTransac()
        {
            return objlistaTipoTransac.ListaTipoTransaccion();
        }
    }
}
