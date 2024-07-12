using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNSexo
    {
        clsADSexo objlistaSexo = new clsADSexo();

        // Crear Método para Recibir Datos en un datatable
        public DataTable ListarSexo()
        {
            return objlistaSexo.ListaSexo();
        }
    }
}
