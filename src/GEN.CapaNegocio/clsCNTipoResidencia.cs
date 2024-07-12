using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipoResidencia
    {
        clsADTipoResidencia objlistaTipoResidencia = new clsADTipoResidencia();

        // Crear Método para Recibir Datos en un datatable
        public DataTable CNListaTipoResidencia()
        {
            return objlistaTipoResidencia.ADListaTipoResidencia();
        }
    }
}

